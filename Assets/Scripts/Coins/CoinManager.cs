using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0);
    }

    private void Update()
    {
        coinText.text = numberOfCoins.ToString();
    }
}
