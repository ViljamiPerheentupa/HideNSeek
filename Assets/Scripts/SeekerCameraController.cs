using UnityEngine;

public class SeekerCameraController : MonoBehaviour
{
    private const float camFollowSpeed = 1f;
    private const float proximity = .01f;
    private const float introHeight = 10f;

    private Transform rig;
        
    private Vector3 prevPos;
    
    private bool gameOn;
    private bool rigged;
    
    private void Start()
    {
        rig = GameObject.Find("SeekerCameraRig").transform;
    }
    
    private void Update()
    {
        if(gameOn || rigged)
            return;
        
        CameraIntro();
    }

    private void CameraIntro()
    {
        var t = transform;
        var pos = t.position;
        var camTargetPos = rig.position + Vector3.up * introHeight;
        var dist = Vector3.Distance(pos, camTargetPos);
        var delta = Time.deltaTime * camFollowSpeed * dist;

        transform.position = Vector3.MoveTowards(pos, camTargetPos, delta);
        
        if(Vector3.Distance(transform.position, camTargetPos) > proximity)
            return;
        
        t.position = rig.position;
        t.rotation = rig.rotation;
        t.parent = rig;
        
        rigged = true;
    }
}
