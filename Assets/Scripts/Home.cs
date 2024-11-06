using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    int delay;

    private void FixedUpdate()
    {
        delay++;
        if (delay > 900)
        {
            SceneManager.LoadScene(0);
        }
    }
}
