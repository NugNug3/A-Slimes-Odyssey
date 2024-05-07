using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInputHandler : MonoBehaviour
{
    [SerializeField] Canvas inGamePause;
    [SerializeField] Canvas inGameSettingsMenu;
    [SerializeField] ScreenFader screenFader;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                inGamePause.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        inGamePause.enabled = false;
        inGameSettingsMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void Settings()
    {
        inGameSettingsMenu.enabled = true;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        screenFader.FadeToColor("MainMenu");
    }
}
