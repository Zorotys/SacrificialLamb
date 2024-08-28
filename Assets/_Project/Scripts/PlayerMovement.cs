using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private enum MovementState {
        Idle,
        Walking,
        Sprinting
    }

    private MovementState movementState;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private Transform orientation;

    [SerializeField] private LayerMask groundLayer;

    private Vector3 moveDir;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        HandleInput();
        HandleSprint();
        Jump();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
    }

    private void HandleInput() {

        // Movement Input
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = 1;
        } if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        } if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        } if (Input.GetKey(KeyCode.D)) {
            inputVector.x = 1;
        }

        moveDir = orientation.forward * inputVector.y + orientation.right * inputVector.x;
        moveDir = moveDir.normalized;

        // Change movement state
        if (Input.GetKey(KeyCode.LeftShift)) {
            movementState = MovementState.Sprinting;
        } else {
            movementState = MovementState.Walking;
        }

        if (inputVector == Vector2.zero) {
            movementState = MovementState.Idle;
        }
    }

    private void HandleSprint() {
        switch (movementState) {
            case MovementState.Walking:
                speed = walkSpeed;
                break;
            case MovementState.Sprinting:
                speed = sprintSpeed;
                break;
        }
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    private bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.2f, groundLayer);
    }

    public bool IsMoving() {
        return movementState != MovementState.Idle;
    }
}
