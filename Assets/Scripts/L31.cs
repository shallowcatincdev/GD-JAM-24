using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L31 : MonoBehaviour
{
    [SerializeField] TextL3 text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            text.line = 2;
            text.NewLine();


        }
    }
}
