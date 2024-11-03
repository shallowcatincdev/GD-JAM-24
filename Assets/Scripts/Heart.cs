using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector2(Random.Range(100, Screen.width - 100), Random.Range(100, Screen.height - 100));
    }
}
