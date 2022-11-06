using UnityEngine; 
public class Character2D : MonoBehaviour
{
    private CharacterController controller;
    
    private const float playerSpeed = 2.0f;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var move = new Vector3(Input.GetAxis("P2HorizontalJoystick"), 0, Input.GetAxis("P2VerticalJoystick")).normalized;
        
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
