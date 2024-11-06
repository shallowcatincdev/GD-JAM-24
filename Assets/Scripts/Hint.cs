using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{

    [SerializeField] GameObject[] hints;
    public int hint = 0;
    public int level;
    bool first;

    public void OnHint()
    {
        if (!first && level == 1)
        {
            first = GameObject.FindGameObjectWithTag("Dialog").GetComponent<TextL1>().Tab();
        }
        hints[hint].SetActive(true);
    }
}
