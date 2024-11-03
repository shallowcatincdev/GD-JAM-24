using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{

    [SerializeField] GameObject[] hints;
    public int hint = 0;

    bool first;

    public void OnHint()
    {
        if (!first)
        {
            first = GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL1>().Tab();
        }
        hints[hint].SetActive(true);
    }
}
