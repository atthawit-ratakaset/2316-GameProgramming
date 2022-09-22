using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    public Animator anim;

    public float jumpForce = 20f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            anim.SetBool("onSpring", true);
            //anim.SetTrigger("Bounce");
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            //anim.SetTrigger("bounce");
            anim.SetBool("onSpring", false);
        }

        if (other.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
