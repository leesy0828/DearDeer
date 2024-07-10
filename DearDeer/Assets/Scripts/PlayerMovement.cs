using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    private Vector3 playerVelocity = Vector3.zero;
    private Vector3 characterRotationX = Vector3.zero;

    [SerializeField] private Camera playerCamera;
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CalculateMove();
        CalculateRotation();
        PerformRotation();
    }

    void FixedUpdate()
    {
        PerformMove();
    }

    private void CalculateMove()
    {
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * moveDirX;
        Vector3 _moveVertical = transform.forward * moveDirZ;

        playerVelocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
    }

    private void CalculateRotation()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float yRotation = Input.GetAxisRaw("Mouse X");
        float cameraRotationX = xRotation * lookSensitivity;

        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        characterRotationX = new Vector3(0, yRotation, 0) * lookSensitivity;
    }

    private void PerformMove()
    {
        if (!Vector3.zero.Equals(playerVelocity))
        {
            rigidBody.MovePosition(transform.position + playerVelocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        if (!Vector3.zero.Equals(characterRotationX))
        {
            rigidBody.MoveRotation(rigidBody.rotation * Quaternion.Euler(characterRotationX));
        }
        if (playerCamera != null)
        {
            playerCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
        }
    }
}
