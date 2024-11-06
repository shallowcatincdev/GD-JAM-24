using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L3Intro : MonoBehaviour
{
    [SerializeField] GameObject hint;

    int charNum;
    string sentence;
    string dialog = " Same as last time take a step to the right.\r\n CLICK TO CONTINUE";
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
    }


    public void OnClick()
    {
        SceneManager.LoadScene(5);
    }

    public void OnHint()
    {
        hint.SetActive(true);
        
    }

}
