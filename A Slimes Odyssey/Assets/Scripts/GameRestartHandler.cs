using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameRestartHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;
    [SerializeField] ScreenFader screenFader;

    void Start()
    {
        highscore.text = CoinCounter.finalCoinSingletonValue;
    }
    public void PlayAgain()
    {
        screenFader.FadeToColor("Level1");
    }

    public void Cowardice()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
