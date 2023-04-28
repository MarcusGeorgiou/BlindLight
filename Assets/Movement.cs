using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInputs controller;
    private Vector2 playerMove;
    private float playerTurn;

    private Rigidbody rb;
    private float speed = 10f;
    private float acceleration;
    private bool isMoving;
    private void OnEnable()
    {
        controller = new PlayerInputs();
        controller.Inputs.Enable();
        
        controller.Inputs.Move.performed += OnPlayerMove;
        controller.Inputs.Move.canceled += OnPlayerMove;

        controller.Inputs.Turn.performed += OnPlayerTurn;
        controller.Inputs.Turn.canceled += OnPlayerTurn;

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isMoving && acceleration < 3f)
            acceleration += 0.05f;

        Vector3 playerVelocity = new Vector3(playerMove.x, 0, playerMove.y);
        rb.AddRelativeForce(playerVelocity * (speed * acceleration));
        
        rb.AddRelativeTorque(Vector3.up * playerTurn);
    }

    private void OnPlayerMove(InputAction.CallbackContext input)
    {
        playerMove = input.ReadValue<Vector2>();

        if (input.performed)
            isMoving = true;
        else
        {
            isMoving = false;
            acceleration = 0;
        }
    }

    private void OnPlayerTurn(InputAction.CallbackContext input)
    {
        playerTurn = input.ReadValue<float>();
    }
}