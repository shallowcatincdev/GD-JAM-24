using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Atm : MonoBehaviour
{
    [SerializeField] Coin coinMaster;
    bool go;
    int delay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinMaster.coins += 15;
            go = true;
            delay = 0;
        }
    }

    private void FixedUpdate()
    {

        delay++;
        if (go && delay >= 120)
        {
            SceneManager.LoadScene(4);
        }
    }
}
