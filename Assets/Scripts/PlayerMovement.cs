using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public string characterPrefix = "Player";
    public string horizontalJoystickname = "HorizontalJoystick";
    public string verticalJoystickname = "VerticalJoystick";
    private CharacterController cc;
    public float speed = 2.0f;
    Vector2 rotation = Vector2.zero;
    public float rotationSpeed = 3;
    public Transform head;
    public float headRotationSpeed = 3;
    Vector2 headRotation = Vector2.zero;
    public float headAngle = 0;

    void Start() {
        cc = GetComponent<CharacterController>();
        horizontalJoystickname = characterPrefix + horizontalJoystickname;
    }

    void Update() {
        //player moves
        Vector3 move = Input.GetAxis("HorizontalJoystick") * transform.right + Input.GetAxis("VerticalJoystick")*transform.forward;
        //Vector3 move = new Vector3(Input.GetAxis("HorizontalJoystick"), 0, Input.GetAxis("VerticalJoystick"));
        cc.Move(move * Time.deltaTime * speed);

        //player rotates
        rotation.y += -Input.GetAxis("HorizontalJoystick2");
        transform.eulerAngles = rotation * rotationSpeed;

        //player head
        headAngle += Time.deltaTime * headRotationSpeed * -Input.GetAxis("VerticalJoystick2");
        headAngle = Mathf.Clamp(headAngle, -45, 45);
        head.localRotation = Quaternion.AngleAxis(headAngle, Vector3.right);
    }

}
