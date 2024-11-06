using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPin : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    [SerializeField] Coin coin;
    [SerializeField] GameObject blueScreen;

    bool spin;
    int delay;
    bool end;
    int wait;

    private void FixedUpdate()
    {
        if (spin && !end)
        {
            delay++;

            wheel.transform.transform.Rotate(new Vector3(0, 0, -1));

            if (delay > 435)
            {
                end = true;
                wait = delay + 5000;
            }
        }

        if (end )
        {
            delay++;

            if (delay %3 == 0)
            {
                coin.coins++;
            }


            if (coin.coins > 500 || delay > wait)
            {
                blueScreen.SetActive(true);
                try
                {
                    FindFirstObjectByType<Canvas>().gameObject.SetActive(false);
                }
                catch
                {

                }
                
                wait = delay + 180;
            }

            if (delay > wait)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void OnClick()
    {
        spin = true;
    }
}
