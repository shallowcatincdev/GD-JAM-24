using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casino : MonoBehaviour
{
    [SerializeField] TextL3 text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            text.line = 3;
            text.NewLine();


        }
    }
}
