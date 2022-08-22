using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float walkSpeed = 0.1f;
    public PlayerController playerControl;
    private InputAction move;
    Vector3 moveDirection = Vector2.zero;
    PlayerInput playerInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerControl = new PlayerController();
        
    }

    private void OnEnable()
    {
        move = playerControl.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector2 inputVector = playerControl.Player.Move.ReadValue<Vector2>();
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * walkSpeed, ForceMode.Acceleration);
    }

}
