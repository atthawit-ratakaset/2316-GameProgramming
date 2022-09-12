using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpFoce = 5f;
    [SerializeField] private float _moveInput;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private ItemColor color;
    [SerializeField] private SpriteRenderer Render;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(jumpFoce * transform.up, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(_moveInput * _moveSpeed, rb.velocity.y);
    }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
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
    }
}
