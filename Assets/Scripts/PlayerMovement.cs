using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public enum Powers
{
    Water,
    Fire,
    Earth,
    Space,
    Air
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 20f;
    Rigidbody2D rb;
    Animator animator;
    Powers currentPower;
    bool isGrounded;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        currentPower=Powers.Water;
    }

    private void Update()
    {
        Movement();
        SelectPower();
        UsePower();
    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if (horizontalInput > 0.01f)
        {

            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKeyDown(KeyCode.W)) 
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
        animator.SetBool("isRunning", horizontalInput != 0);
        animator.SetFloat("jumpVelocity",rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }
    public void UsePower()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentPower)
            {
                case Powers.Water:
                    animator.SetTrigger("Attack");
                    GetComponent<PowerWater>().UsePower();
                    break;
                case Powers.Fire:
                    animator.SetTrigger("Attack");
                    GetComponent<PowerFire>().UsePower();
                    break;
                case Powers.Space:
                    GetComponent<PowerSpace>().UsePower();
                    break;
                case Powers.Air:
                    GetComponent<PowerAir>().UsePower();
                    break;
                case Powers.Earth:
                    GetComponent<PowerEarth>().UsePower();
                    break;
            }
        }
    }

    public void SelectPower()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentPower = Powers.Water;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentPower = Powers.Fire;
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentPower = Powers.Space;
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentPower = Powers.Air;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentPower = Powers.Earth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "ice")
        {
            isGrounded=true;
        }
    }

}
