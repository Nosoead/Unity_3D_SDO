using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 2.0f;
    public float forwardRunSpeed = 7.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2.0f;

    private Rigidbody movementRigidbody;
    private InputHandler inputHandler;
    private float moveDirection = 0;
    private float moveRotate = 0;
    private bool isRunning = false;

    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
    }

    private void OnEnable()
    {
        inputHandler.OnMoveEvent += OnMovement;
        inputHandler.OnVelocityUpEvent += OnVelocityUp;
    }

    private void OnDisable()
    {
        inputHandler.OnMoveEvent -= OnMovement;
        inputHandler.OnVelocityUpEvent -= OnVelocityUp;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
        ApplyRotate(moveRotate);
    }

    private void OnMovement(Vector2 direction)
    {
        moveDirection = direction.y;
        moveRotate = direction.x * rotateSpeed;
    }

    private void OnVelocityUp(bool isPressed)
    {
        isRunning = isPressed;
    }

    private void ApplyMovement(float moveDirection)
    {
        Vector3 currentDirection = transform.forward * moveDirection;
        bool isMovingBackward = Vector3.Dot(currentDirection, transform.forward) < 0;
        float currentSpeed = isMovingBackward ? forwardSpeed : (isRunning ? forwardRunSpeed : forwardSpeed);
        currentDirection = currentDirection.normalized * currentSpeed;
        currentDirection.y = movementRigidbody.velocity.y;
        movementRigidbody.velocity = currentDirection;
    }

    private void ApplyRotate(float moveRotate)
    {
        transform.Rotate(0, moveRotate, 0);
    }
}
