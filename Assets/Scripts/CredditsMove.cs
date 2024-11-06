using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CredditsMove : MonoBehaviour
{
    int delay;
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(0, 1));
        delay++;
        if (delay >= 4700)
        {
            SceneManager.LoadScene(0);
        }
    }
}
