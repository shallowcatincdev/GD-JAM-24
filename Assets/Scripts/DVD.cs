using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVD : MonoBehaviour
{
    Vector2 direction;
    public int deadZonex;
    public int deadZoney;

    void Start()
    {
        int temp = Random.Range(0, 4); 
        if (temp == 0)
        {
            direction = new Vector2(1,1);
        }
        else if (temp == 1)
        {
            direction = new Vector2(1, -1);
        }
        else if (temp == 2)
        {
            direction = new Vector2(-1, -1);
        }
        else
        {
            direction = new Vector2(-1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.Translate(direction * Time.deltaTime * 30);

        if (transform.position.x > Screen.width - deadZonex)
        {
            direction.x = -1;
        }
        if (transform.position.x < 0 + deadZonex)
        {
            direction.x = 1;
        }
        if (transform.position.y > Screen.height - deadZoney)
        {
            direction.y = -1;
        }
        if (transform.position.y < 0 + deadZoney)
        {
            direction.y = 1;
        }
    }
}
