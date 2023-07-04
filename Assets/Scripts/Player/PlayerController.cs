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
    private Vector2 size;
    private CapsuleCollider2D capsuleCollider2D;
    public bool isCrouch;

    [Header("Basic Values")]
    public float speed;
    private float walkSpeed;
    private float normalSpeed;
    public float jumpForce;
    private int FacDir;
    private void Awake()
    {
        inputControll = new PlayerInputControll();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        inputControll.Gameplay.Jump.started += Jump;
        normalSpeed = speed;
        walkSpeed = speed / 2.5f;
        size = new Vector2(1.025955f, 1.877274f);
        inputControll.Gameplay.Walk.performed += ctx =>
        {
            if (physicsCheck.isGround)
            {
                speed = walkSpeed;
            }
        };
        inputControll.Gameplay.Walk.canceled += ctx =>
        {
            if (physicsCheck.isGround) { speed = normalSpeed; }
        };


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
        if (inputDirection.y < -0.5)
        {
            isCrouch = true;
            capsuleCollider2D.size = new Vector2(1.025955f, 1.49f);
        }
        else
        {
            isCrouch = false;
            capsuleCollider2D.size = size;
        }
    }
    private void FixedUpdate()
    {
        if (!isCrouch)
        {
            Move();
        }
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
        //crouch

    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }



}
