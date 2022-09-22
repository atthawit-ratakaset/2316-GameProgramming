using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private PlayerAnimatorController animatorController; 
    [SerializeField] private ItemColor color;
    [SerializeField] private SpriteRenderer Render;
    
    
    [Header("Player Values")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float _moveSpeed = 3f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 0.01f;

    private float _moveInput;

    private bool _isGrounded;

    private bool coyoteJump;


    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        TryJumping();
        
    }
    private void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * _moveSpeed, rb.velocity.y);
    }
    
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        FlipPlayerSprite();

    }
    /*private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent(out ItemChangeFunc itemChangeFunc))
        {
            ItemColor color = itemChangeFunc.color;

            switch (color)
            {
                case ItemColor.Red:
                    Render.color = Color.red;
                    break;
                case ItemColor.Green:
                    Render.color = Color.green;
                    break;
                case ItemColor.Blue:
                    Render.color = Color.blue;
                    break;

            }
            Destroy(itemChangeFunc.gameObject);
        }
    }*/
    private void Update() 
    {
        CheckGround();
        SetAnimatorParameter();

    }
    
    private void SetAnimatorParameter()
    {
        animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);

    }
    private void FlipPlayerSprite()
    {
        if (_moveInput < 0)
        {
            player.localScale = new Vector3(-1, 1, 1);

        }
        else if (_moveInput > 0)
        {
            player.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(force * transform.up, ForceMode2D.Impulse);

    }
    private void TryJumping()
    {
        //if (!_isGrounded) return;
        if (_isGrounded)
        {
            Jump(jumpForce); 
        }
        else
        {
            if (coyoteJump)
            {
                Jump(jumpForce);
                Debug.Log("COYOTE JUMP!");
            }
        }
    }
    private void CheckGround()
    {
        var playerBounds = playerCollider.bounds;

        RaycastHit2D raycastHit =  
                    Physics2D.BoxCast(playerBounds.center, 
                        playerBounds.size, 
                        0f, 
                        Vector2.down,
                        groundCheckDistance,
                        groundLayers);
        //_isGrounded = raycastHit.collider != null;

        

        if (raycastHit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
            StartCoroutine(CoyoteJumpDelay());
        }
    }

    private IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(0.15f);
        coyoteJump = false;
    }

}
