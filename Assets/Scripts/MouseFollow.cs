using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] Camera cam;
    Vector2 mousePos;
    GameObject hoverObj;
    bool follow = true;
    public float speed;

    private void Start()
    {

    }

    private void Update()
    {
        var mouse = cam.ScreenToWorldPoint(mousePos);
        if (follow)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector3(mouse.x + 1.675f, mouse.y + 0.3f), speed * Time.deltaTime);
        }
        

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            hoverObj = collision.gameObject;
        }
    }
    public void OnMouse(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            hoverObj = null;
        }
    }

    public void OnClick()
    {
        if (hoverObj != null)
        {
            hoverObj.GetComponent<Fish>().Caught(gameObject);
            follow = false;
        }
    }

}
