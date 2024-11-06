using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movment : MonoBehaviour
{
    [SerializeField] HealthMaster health;
    [SerializeField] GameObject hint1;
    [SerializeField] GameObject hint2;
    Vector2 moveDirection;
    public int level;
    bool sprinting;
    int hint = 1;
    public float walkSpeed;
    public float sprintSpeed;

    public int jumpStrength;
    bool grounded;
    float speed;
    bool jump;
    int delay;
    Rigidbody2D rb;
    bool first;
    string l3Click;
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
        else if (collision.gameObject.tag == "Hurt")
        {
            health.health--;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "House" || collision.tag == "Casino")
        {
            l3Click = collision.tag;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        l3Click = null;
    }

    private void Start()
    {
        speed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        if (level != 2)
        {
            hint = 0;
        }
    }

    private void FixedUpdate()
    {
        var move = new Vector2(transform.position.x + moveDirection.x * speed / 100, transform.position.y);
        delay++;



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

        if (level == 2 && moveDirection.y < 0 && delay >= 5 && !first)
        {
            first = true;
            try
            {
                if (GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().gotHint)
                {
                    GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().line = 3;
                    GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().NewLine();
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().line = 2;
                    GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().NewLine();
                }
            }
            catch
            {
                GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().line = 2;
                GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().NewLine();
            }
        }
    }

    public void OnClick()
    {
        if (level == 3)
        {
            if (l3Click == "House")
            {
                SceneManager.LoadScene(7);
            }
            if(l3Click == "Casino")
            {
                SceneManager.LoadScene(6);
            }
        }

        
    }

    public void OnHint()
    {
        if (hint == 1)
        {
            hint1.SetActive(true);
            hint = 2;
     

            GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().line = 5;
            GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().NewLine();
        }
        else if (hint == 2) 
        {
            hint1.SetActive(false);
            hint2.SetActive(true);


            GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().line = 6;
            GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL2>().NewLine();
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
