using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextL5 : MonoBehaviour
{


    string[] dialog = new string[]
    {
        "The story begins with Bob, who has just clocked out from his shift at Denny's. As he steps outside the door, ready to head home, he suddenly remembers he needs to cash his paycheck. With a quick decision, he turns and heads toward the bank to his right.",
        "If you ever need help you can get a hint with the [TAB] key.",
        "Well...   Thats not quite right but its trying its best, alright.",
        "I guess I’ll just help you for now. You can use those keys on the left to move and the big one at the bottom to jump.",
        "Well nevermind i guess you don't need help. Good luck because i'm leaving.",
        "As you walk along you find what apears to be a masive pit of doom. You pay no atention to it just being sure to use that shift key of yours to make it across the gap."
    };
    int charNum;
    string sentence;
    int delay;
    bool printing = true;
    int line;

    private void Start()
    {
        line = 1;
    }

    public bool Tab()
    {
        if (line == -2 || line == 2)
        {
            GetComponent<TextMeshProUGUI>().text = null;
            delay = 0;
            sentence = null;
            printing = true;
            line = 3;
            charNum = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FixedUpdate()
    {
        delay++;



        if (line == 1 && printing && dialog[0].Length > charNum && delay % 2 == 0)
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


        if (line == -1 && delay >= 150)
        {
            sentence = null;
            GetComponent<TextMeshProUGUI>().text = null;
            delay = 0;
            line = 2;
            printing = true;
        }


        if (line == 2 && printing && dialog[1].Length > charNum && delay % 2 == 0)
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

        if (line == 3 && printing && dialog[2].Length > charNum && delay % 2 == 0)
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

        if (line == 4 && printing && dialog[3].Length > charNum && delay % 2 == 0)
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

        if (line == 5 && printing && dialog[4].Length > charNum && delay % 2 == 0)
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
    }
}
