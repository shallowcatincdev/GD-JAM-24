using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthMaster : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;

    public int health;

    List<GameObject> hearts = new List<GameObject>();

    private void Start()
    {
        try
        {
            health = GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().health;
        }
        catch
        {

        }
    }


    void Update()
    {

        try
        {
            GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().health = health;
        }
        catch
        {

        }

        if (hearts.Count > health)
        {
            var temp = Random.Range(0, hearts.Count);
            var temp2 = hearts[temp];
            hearts.Remove(hearts[temp]);
            Destroy(temp2);
        }
        else if (hearts.Count < health)
        {
            var temp = Instantiate(heartPrefab, transform);
            hearts.Add(temp);
        }
    }
}
