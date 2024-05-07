using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    public static CoinCounter coinSingleton;
    public static string finalCoinSingletonValue;
    int coinsCollected = 0;
    const int coinGain = 100;
    // Start is called before the first frame update
    void Start()
    {
        coinSingleton = this;
        coinText.text = "0";
    }

    public void AddCoin()
    {
        coinsCollected += coinGain;
        coinText.text = coinsCollected.ToString();
    }

    public string ShowCoins()
    {
        coinText.text = coinsCollected.ToString();
        return coinText.text;
    }
}
