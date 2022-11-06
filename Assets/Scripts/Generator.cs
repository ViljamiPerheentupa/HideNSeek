using Muc.Components.Extended;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Singleton<Generator>
{
    public int cellSize = 5;
    public Vector2Int gridSize = new Vector2Int(5, 5);

    public List<RoomCategory> roomCategories;

    [HideInInspector]
    public bool generated;

    public void Degenerate()
    {
        this.generated = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    // Update is called once per frame
    public void Generate()
    {
        if (this.generated)
            Degenerate();
        this.generated = true;
        var generated = 0;
        var cellCount = gridSize.x * gridSize.y;
        var generatedRooms = new RoomCategory[gridSize.x, gridSize.y];

        for (int catIndex = 0; catIndex < roomCategories.Count; catIndex++)
        {
            var cat = roomCategories[catIndex];
            var genCount = UnityEngine.Random.Range(cat.minRoomCount < 0 ? cellCount - generated : cat.minRoomCount, cat.maxRoomCount < 0 ? cellCount - generated : cat.maxRoomCount + 1);
            var roomSelectCount = new int[cat.rooms.Count];
            var roomBans = 0;
            var distBlockedCount = 0;
            var distBlocked = new bool[gridSize.x, gridSize.y];
            for (int i = 0; i < genCount; i++)
            {
                var prefab = GetRandomRoomPrefab();
                var index = GetRandomFreeRoomIndex();
                generatedRooms[index.x, index.y] = cat;
                var pos = new Vector3(index.x, 0, index.y) * cellSize;
                var room = Instantiate(prefab, pos, Quaternion.identity, transform);

                GameObject GetRandomRoomPrefab()
                {
                    if (cat.singleRoomUseLimit <= 0) return cat.rooms[UnityEngine.Random.Range(0, cat.rooms.Count)];

                    var ranIndex = UnityEngine.Random.Range(0, cat.rooms.Count - roomBans - distBlockedCount);
                    var current = 0;
                    for (int j = 0; j <= ranIndex; j++)
                    {
                        if (current >= cat.rooms.Count)
                        {
                            throw new InvalidOperationException($"{nameof(cat.singleRoomUseLimit)} is too low for category at index {catIndex}");
                        }
                        if (roomSelectCount[current] >= cat.singleRoomUseLimit) {
                            j--;
                        }
                        current++;
                    }


                    roomSelectCount[current-1]++;
                    if (roomSelectCount[current-1] >= cat.singleRoomUseLimit)
                    {
                        roomBans++;
                    }
                    return cat.rooms[current-1];

                }
            }

            Vector2Int GetRandomFreeRoomIndex()
            {
                return GetFreeRoomIndex(UnityEngine.Random.Range(0, cellCount - generated - distBlockedCount));
            }

            Vector2Int GetFreeRoomIndex(int index)
            {
                var current = 0;
                var current2d = default(Vector2Int);
                for (int i = 0; i <= index; i++)
                {
                    current2d = new Vector2Int(current / gridSize.y, current % gridSize.y);
                    current++;
                    if (generatedRooms[current2d.x, current2d.y] != default) i--;
                    else if (cat.minDist > 1 && distBlocked[current2d.x, current2d.y]) i--;
                }

                if (cat.minDist > 1)
                {

                    if (distBlocked[current2d.x, current2d.y])
                    {
                        distBlocked[current2d.x, current2d.y] = default;
                        distBlockedCount--;
                    }

                    BlockCells(new (1, 0), new (-1, 1));
                    BlockCells(new (0, 1), new (-1, -1));
                    BlockCells(new(-1, 0), new(1, -1));
                    BlockCells(new(0, -1), new(1, 1));

                    void BlockCells(Vector2Int offset, Vector2Int subOffset)
                    {
                        for (int i = 1; i < cat.minDist; i++)
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                var currentOffset = GridUtil.LoopIndex(current2d + offset * i + subOffset * j);
                                if (generatedRooms[currentOffset.x, currentOffset.y] == null && !distBlocked[currentOffset.x, currentOffset.y])
                                {
                                    distBlocked[currentOffset.x, currentOffset.y] = true;
                                    distBlockedCount++;
                                }
                            }
                        }
                    }
                }

                generated++;

                return current2d;

            }
        }

    }

    [Serializable]
    public class RoomCategory
    {
        public List<GameObject> rooms;
        public int minRoomCount = -1;
        public int maxRoomCount = -1;
        public int singleRoomUseLimit = -1;
        public int minDist = 0;
    }
}

#if UNITY_EDITOR
namespace Editors
{

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    using Object = UnityEngine.Object;
    using static Muc.Editor.PropertyUtil;
    using static Muc.Editor.EditorUtil;

    [CanEditMultipleObjects]
    [CustomEditor(typeof(Generator), true)]
    public class GeneratorEditor : Editor
    {

        Generator t => (Generator)target;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            using(DisabledScope(!Application.isPlaying))
            {
                if (ButtonField(new(nameof(t.Generate))))
                {
                    t.Generate();
                }
                if (ButtonField(new(nameof(t.Degenerate))))
                {
                t.Degenerate();
                }
            }
        }
    }
}
#endif