using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fish : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject settings;

    bool caught = false;
    GameObject rod;
    Vector2 targetPos;
    Vector2 targetPosRod;
    bool first = true;
    public int type;
    public float speed;
    Vector2 pos;
    Vector2 target;

    public void Caught(GameObject Rod)
    {
        caught = true;
        rod = Rod;
    }

    private void Start()
    {
        pos.x = Random.Range(0, 14) - 7;
        pos.y = (Random.Range(0, 6) - 2 ) * -1;

        parent.transform.position = pos;

        target.x = Random.Range(0, 14) - 7;
        target.y = (Random.Range(0, 6) - 2) * -1;
    }

    private void FixedUpdate()
    {
        if (!caught)
        {
            pos = Vector2.Lerp(pos, target, speed / 10 * Time.deltaTime);
            parent.transform.position = pos;

            if (pos.x >= target.x - 0.4 && pos.x <= target.x + 0.4 && pos.y >= target.y - 0.4 && pos.y <= target.y + 0.4)
            {
                target.x = Random.Range(0, 14) - 7;
                target.y = (Random.Range(0, 6) - 2) * -1;
            }
        }
        


        if (caught)
        {
            if (first)
            {
                targetPosRod = new Vector2( rod.transform.position.x, rod.transform.position.y + 2);
                targetPos = new Vector2(transform.position.x, transform.position.y + 2);
                first = false;
            }
            var moveRod = Vector2.Lerp(rod.transform.position, targetPosRod, 1 * Time.deltaTime);
            var moveFish = Vector2.Lerp(transform.position, targetPos, 1 * Time.deltaTime);

            rod.transform.position = moveRod;
            transform.position = moveFish;

            var temp = parent.GetComponent<SpriteRenderer>().color;
            temp.a -= 0.05f;
            parent.GetComponent<SpriteRenderer>().color = temp;

            var temp2 = GetComponent<SpriteRenderer>().color;
            temp2.a += 0.05f;
            GetComponent<SpriteRenderer>().color = temp2;

            if (temp.a <= 0)
            {
                if (type == 0)
                {
                    SceneManager.LoadScene(1);
                }
                else if (type == 1)
                {
                    settings.SetActive(true);
                }
                else if(type == 2)
                {
                    Application.Quit();
                }
                else if (type == 3)
                {

                }
                else if (type == 4)
                {

                }
            }
        }
    }
}
