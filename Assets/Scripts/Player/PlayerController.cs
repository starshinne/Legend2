using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInputControll inputControll;
    public Rigidbody2D rb;
    public Vector2 inputDirection;
    private PhysicsCheck physicsCheck;
    [Header("Basic Values")]
    public float speed;
    public float jumpForce;
    private int FacDir;
    private void Awake()
    {
        inputControll = new PlayerInputControll();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck=GetComponent<PhysicsCheck>();
        inputControll.Gameplay.Jump.started += Jump;
    }



    private void OnEnable()
    {
        inputControll.Enable();
    }

    private void OnDisable()
    {
        inputControll.Disable();
    }
    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        inputDirection = inputControll.Gameplay.Move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Move();
        if (transform.localScale == new Vector3(0, 1, 1))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        if (inputDirection.x > 0) { FacDir = 1; }
        if (inputDirection.x < 0) { FacDir = -1; }
        transform.localScale = new Vector3(FacDir, 1, 1);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
