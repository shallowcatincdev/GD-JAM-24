using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movment : MonoBehaviour
{
    [SerializeField] HealthMaster health;
    Vector2 moveDirection;
    public int level;
    bool sprinting;

    public float walkSpeed;
    public float sprintSpeed;

    public int jumpStrength;
    bool grounded;
    float speed;
    bool jump;

    Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else if (collision.gameObject.tag == "Kill")
        {
            health.health = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void Start()
    {
        speed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var move = new Vector2(transform.position.x + moveDirection.x * speed / 100, transform.position.y);

        if (health.health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if (moveDirection.y > 0)
        {
            jump = true;
        }
        if (moveDirection.x != 0)
        {
            transform.position = move;
        }
        if (grounded && jump)
        {
            rb.AddForce(Vector2.up * jumpStrength);
            grounded = false;
            jump = false;
        }
        else
        {
            jump = false;
        }
    }

    public void OnJump()
    {
        jump = true;
        
    }

    public void OnMoveL1(InputValue value)
    {
        if (level == 1)
        {
            moveDirection = value.Get<Vector2>();
        }
    }

    public void OnMoveL2(InputValue value)
    {
        if (level == 2)
        {
            moveDirection = value.Get<Vector2>();
        }
    }

    public void OnMoveL3(InputValue value)
    {
        if (level == 3)
        {
            moveDirection = value.Get<Vector2>();
        }
    }

    public void OnMoveL4(InputValue value)
    {
        if (level == 4)
        {
            moveDirection = value.Get<Vector2>();
        }
    }

    public void OnMoveL5(InputValue value)
    {
        if (level == 5)
        {
            moveDirection = value.Get<Vector2>();
        }
    }

    public void OnSprint()
    {
        if (sprinting)
        {
            speed = walkSpeed;
            sprinting = false;
        }
        else
        {
            speed = sprintSpeed;
            sprinting = true;
        }
    }



}
