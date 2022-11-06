using UnityEngine;

public class HiderCameraController : MonoBehaviour
{
    private const float camFollowHeight = 10f;
    private const float camFollowSpeed = 1f;
    private const float camRotationSpeed = 5f;
    private const float introHeight = 10f;
    private float angleFactor = .1f;
    private const float proximity = 15f;
    private const float lookAngle = 1f;
    
    private Transform hider;

    private Vector3 prevPos;
    
    private bool gameOn;
    private bool rigged;


    private void Start()
    {
        hider = GameObject.Find("HiderNEW").transform;
    }
    
    private void Update()
    {
        if (!GameManager.instance.gameOn)
            return;

        if (!rigged)
        {
            CameraIntro();
            return;
        }
        
        CameraChase();
    }

    private void CameraChase()
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
    
    private void CameraIntro()
    {
        var pos = transform.position;
        var camTargetPos = hider.position + Vector3.up * introHeight;
        var dist = Vector3.Distance(pos, camTargetPos);
        var delta = Time.deltaTime * camFollowSpeed * dist;

        transform.position = Vector3.MoveTowards(pos, camTargetPos, delta);
        
        if(dist > proximity)
            return;
        
        var down = Quaternion.LookRotation(Vector3.down, Vector3.forward);
        var rotation = transform.rotation;
        var angle = Quaternion.Angle(down, rotation);
        var rotationStep = Time.deltaTime * camRotationSpeed * (angle * angleFactor); 
        var targetRotation = Quaternion.RotateTowards( rotation, down, rotationStep);

        transform.rotation = targetRotation;

        if(angle > lookAngle)
            return;

        transform.rotation = down;
        rigged = true;
    }
}
