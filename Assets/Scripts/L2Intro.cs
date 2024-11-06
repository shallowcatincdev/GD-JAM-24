using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2Intro : MonoBehaviour
{
    [SerializeField] GameObject hint;
    [SerializeField] GameObject hint2;

    int charNum;
    string sentence;
    string dialog = " Now i should warn you there seems to be some.... isues with your brain and for whatever reason your legs stop working right when you enter new levels. now it isnt the end of the world you just need to take a step to the right. or you know, the hint guy might know how to help.\r\n CLICK TO CONTINUE";
    bool printing = true;
    int delay;
    bool killed;


    void Start()
    {
        try
        {
            killed = GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().killNarrartor;
        }
        catch
        {
            
        }
    }

    
    void FixedUpdate()
    {
        if (killed)
        {
            GetComponent<TextMeshProUGUI>().text = "CLICK TO CONTINUE";
        }




        delay++;
        if (printing && delay %2 == 0 && !killed) 
        {
            sentence += dialog[charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
                if (dialog.Length == charNum)
                {
                    printing = false;
                }
        }

        if (printing && hint.activeInHierarchy == true && delay % 2 == 0 && !killed)
        {
            dialog = " Thats not quite right. He knows your using a keboard right. mabye try again?\r\n CLICK TO CONTINUE";
            sentence += dialog[charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog.Length == charNum)
            {
                printing = false;
            }
        }

        if (printing && hint2.activeInHierarchy == true && delay % 2 == 0 && !killed)
        {
            dialog = " I give up you move your fingers to the right no more wasd now its esdf.\r\n CLICK TO CONTINUE";
            sentence += dialog[charNum];
            charNum++;
            GetComponent<TextMeshProUGUI>().text = sentence;
            if (dialog.Length == charNum)
            {
                printing = false;
            }
        }
    }


    public void OnClick()
    {
        SceneManager.LoadScene(3);
    }

    public void OnHint()
    {
        if (hint.activeInHierarchy == true)
        {
            hint.SetActive(false);
            hint2.SetActive(true);
            printing = true;
            charNum = 0;
            sentence = null;

            try
            {
                GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().gotHint = true;
            }
            catch
            {

            }

        }
        else
        {
            hint.SetActive(true);
            printing = true;
            charNum = 0;
            sentence = null;
        }
        
    }

}
