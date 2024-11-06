using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presistent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this); 
    }

    public bool killNarrartor;
    public int health;
    public int money;
    public bool gotHint;
}
