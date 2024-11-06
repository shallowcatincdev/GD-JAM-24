using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextL3 : MonoBehaviour
{


    string[] dialog = new string[]
    {
        "You leave the bank finaly making your way home.",
        "On the way to your house you pass the towns new casino. You see it's there grand opening, having just receved your paycheck you know you have the cash to spare. Do you?",
        "You reach the casino. Do you go in?\r\nCLICK TO ENTER",
        "You reach your house. Do you go in?\r\nCLICK TO ENTER"
    };
    int charNum;
    string sentence;
    int delay;
    bool printing = true;
    public int line;
    bool killed;

    private void Start()
    {
        line = 1;
        killed = GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().killNarrartor;
    }

    public void NewLine()
    {
        GetComponent<TextMeshProUGUI>().text = null;
        delay = 0;
        sentence = null;
        printing = true;
        charNum = 0;
    }


    private void FixedUpdate()
    {
        delay++;

        if (!killed && line == 1 && printing && dialog[0].Length > charNum && delay % 2 == 0)
        {
            sentence += dialog[0][charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog[0].Length == charNum)
            {
                printing = false;
                charNum = 0;
                line = -1;
                delay = 0;
            }
        }


        if (!killed && line == 2 && printing && dialog[1].Length > charNum && delay % 2 == 0)
        {
            sentence += dialog[1][charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog[1].Length == charNum)
            {
                printing = false;
                charNum = 0;
                line = -2;
            }
        }

        if (!killed && line == 3 && printing && dialog[2].Length > charNum && delay % 2 == 0)
        {
            sentence += dialog[2][charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog[2].Length == charNum)
            {
                printing = false;
                charNum = 0;
                line = -3;
            }
        }

        if (!killed && line == 4 && printing && dialog[3].Length > charNum && delay % 2 == 0)
        {
            sentence += dialog[3][charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog[3].Length == charNum)
            {
                printing = false;
                charNum = 0;
                line = -4;
            }
        }

        if (!killed && line == 5 && printing && dialog[4].Length > charNum && delay % 2 == 0)
        {
            sentence += dialog[4][charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog[4].Length == charNum)
            {
                printing = false;
                charNum = 0;
                line = -5;
            }
        }

        if (!killed && line == 6 && printing && dialog[5].Length > charNum && delay % 2 == 0)
        {
            sentence += dialog[5][charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog[5].Length == charNum)
            {
                printing = false;
                charNum = 0;
                line = -6;
            }
        }
    }
}
