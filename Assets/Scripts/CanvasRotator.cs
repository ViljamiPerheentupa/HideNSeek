using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    private Transform seeker;
    private void Start()
    {
        seeker = GameObject.Find("SeekerNEW").transform;
    }

    private void Update()
    {
        transform.LookAt(seeker, Vector3.up);
    }
}
