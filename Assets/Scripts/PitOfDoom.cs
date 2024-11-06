using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitOfDoom : MonoBehaviour
{
    [SerializeField] TextL1 text;
    public int lineNum;
    public int level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (text.line >= 4 || text.line <= -3)
            {
                text.line = 5;
                text.NewLine();
            }
            else
            {
                text.line = 6;
                text.NewLine();
            }

        }
    }
}
