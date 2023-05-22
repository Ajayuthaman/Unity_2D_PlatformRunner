using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            CoinManager.numberOfCoins++;
            PlayerPrefs.SetInt("NumberOfCoins",CoinManager.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
