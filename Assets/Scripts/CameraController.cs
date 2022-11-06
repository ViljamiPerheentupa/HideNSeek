using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform hider;
    private const float camFollowHeight = 5f;
    private const float camFollowSpeed = 1f;
    private Vector3 prevPos;

    private void Start()
    {
        hider = GameObject.Find("Hider").transform;
    }
    
    private void Update()
    {
        var hiderPos = hider.position;
        var hiderSpeed = Vector3.Distance(prevPos, hiderPos);
        var pos = transform.position;
        var camTargetPos = hiderPos + hider.forward * hiderSpeed * 1000f + Vector3.up * camFollowHeight;
        var dist = Vector3.Distance(pos, camTargetPos);
        var delta = Time.deltaTime * camFollowSpeed * dist;

        transform.position = Vector3.MoveTowards(pos, camTargetPos, delta);
        prevPos = hiderPos;
    }
}
