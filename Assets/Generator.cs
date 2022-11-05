using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int cellSize = 5;
    public Vector2Int gridSize = new Vector2Int(5, 5);

    public List<RoomCategory> roomCategories;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Generate()
    {
        var generated = 0;
        var cellCount = gridSize.x * gridSize.y;
        var generatedRooms = new RoomCategory[gridSize.x, gridSize.y];

        foreach (var cat in roomCategories)
        {
            var genCount = UnityEngine.Random.Range(cat.minRoomCount < 0 ? cellCount - generated : cat.minRoomCount, cat.maxRoomCount < 0 ? cellCount - generated : cat.maxRoomCount + 1);
            for (int i = 0; i < genCount; i++)
            {
                var prefab = cat.rooms[UnityEngine.Random.Range(0, cat.rooms.Count)];
                var index = GetRandomFreeRoomIndex();
                generatedRooms[index.x, index.y] = cat;
                var pos = new Vector3(index.x, 0, index.y) * cellSize;
                var room = Instantiate(prefab, pos, Quaternion.identity, transform);
            }
        }

        Vector2Int GetRandomFreeRoomIndex(bool increment = true)
        {
            return GetFreeRoomIndex(UnityEngine.Random.Range(0, cellCount - generated), increment);
        }

        Vector2Int GetFreeRoomIndex(int index, bool increment = true)
        {
            var current = 0;
            var current2d = default(Vector2Int);
            for (int i = 0; i <= index; i++)
            {
                current2d = new Vector2Int(current / gridSize.x, current % gridSize.y);
                current++;
                if (generatedRooms[current2d.x, current2d.y] != default) i--;
            }

            if (increment) { generated++; }
            return current2d;

        }
    }

    [Serializable]
    public class RoomCategory
    {
        public List<GameObject> rooms;
        public int minRoomCount = -1;
        public int maxRoomCount = -1;
        public bool requiredRoomsUnique = false;
        public int minDist = 0;
    }
}
