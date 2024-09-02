using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Movement movement;
    AnimatorManager animatorManager;
    public Vector2 movementInput;
    public Vector2 cameraInput;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public float cameraInputX;
    public float cameraInputY;
    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }
    private void OnEnable()
    {
        if (movement == null)
        {
            movement = new Movement();
            movement.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            movement.PlayerMovement.Camera.performed += i =>cameraInput =  i.ReadValue<Vector2>();
        }
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
