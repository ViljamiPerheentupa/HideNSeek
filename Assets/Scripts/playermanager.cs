using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour {
    private CharacterController cc;
    public float speed = 2.0f;
    Vector2 rotation = Vector2.zero;
    public float rotationSpeed = 3;

    void Start() {
        cc = GetComponent<CharacterController>();
    }

    void Update() {
        Vector3 move = new Vector3(Input.GetAxis("VerticalJoystick"), 0, Input.GetAxis("HorizontalJoystick"));
        cc.Move(move * Time.deltaTime * speed);

        rotation.y += Mathf.Clamp(Input.GetAxis("VerticalJoystick2"), -90, 90);
        rotation.x += -Input.GetAxis("HorizontalJoystick2");
        transform.eulerAngles = (Vector2)rotation * rotationSpeed;
    }

}
