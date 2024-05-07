using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winhandler : MonoBehaviour
{
    [SerializeField] ScreenFader screenFader;
    [SerializeField] TextMeshProUGUI highscore;
    
    void Start()
    {
        highscore.text = CoinCounter.finalCoinSingletonValue;
    }
    public void PlayAgain()
    {
        screenFader.FadeToColor("Level1");
    }

    public void Quit()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
