using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public string characterPrefix = "Player";
    public string horizontalJoystickname = "HorizontalJoystick";
    public string verticalJoystickname = "VerticalJoystick";
    public string horizontalJoystick2name = "HorizontalJoystick2";
    public string verticalJoystick2name = "VerticalJoystick2";

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
        verticalJoystickname = characterPrefix + verticalJoystickname;
        horizontalJoystick2name = characterPrefix + horizontalJoystick2name;
        verticalJoystick2name = characterPrefix + verticalJoystick2name;
    }

    void Update() {
        //player moves
        Vector3 move = Input.GetAxis(horizontalJoystickname) * transform.right + Input.GetAxis(verticalJoystickname)*transform.forward;
        //Vector3 move = new Vector3(Input.GetAxis("HorizontalJoystick"), 0, Input.GetAxis("VerticalJoystick"));
        cc.Move(move * Time.deltaTime * speed);

        //player rotates
        rotation.y += -Input.GetAxis(horizontalJoystick2name);
        transform.eulerAngles = rotation * rotationSpeed;

        //player head
        headAngle += Time.deltaTime * headRotationSpeed * -Input.GetAxis(verticalJoystick2name);
        headAngle = Mathf.Clamp(headAngle, -45, 45);
        head.localRotation = Quaternion.AngleAxis(headAngle, Vector3.right);
    }

}
