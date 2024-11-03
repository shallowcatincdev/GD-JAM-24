using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthMaster : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;

    public float health;

    List<GameObject> hearts = new List<GameObject>();


    void Update()
    {
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
