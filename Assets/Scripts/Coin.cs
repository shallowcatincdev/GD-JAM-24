using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;

    public int coins;

    List<GameObject> coinsList = new List<GameObject>();


    private void Start()
    {
        try
        {
            coins = GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().money;
        }
        catch
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

        try
        {
            GameObject.FindGameObjectWithTag("Info").GetComponent<Presistent>().money = coins;
        }
        catch
        {

        }

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
