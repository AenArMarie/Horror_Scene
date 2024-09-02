using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CameraManager cameraManager;
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();
        Cursor.visible = false;
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
