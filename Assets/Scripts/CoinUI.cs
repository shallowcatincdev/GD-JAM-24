using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(100, Screen.width -100), Random.Range(100, Screen.height-100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
