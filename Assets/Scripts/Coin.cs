using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;

    public float coins;

    List<GameObject> coinsList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (coinsList.Count > coins)
        {
            coinsList.Remove(coinsList[Random.Range(0,coinsList.Count)]);
        }
        else if (coinsList.Count < coins)
        {
            var temp = Instantiate(coinPrefab, transform);
            coinsList.Add(temp);
        }
    }
}
