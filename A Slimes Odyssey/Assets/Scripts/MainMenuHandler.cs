using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //This will allow us to change scenes as needed

public class MainMenuHandler : MonoBehaviour
{

public GameObject openSettings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This method ties the OnClick event handler to the "Start" button to start the game
    public void Play()  
    {
        SceneManager.LoadScene("Game");
    }

    //Opens up the settings panel
    public void Settings()
    {
        if(openSettings != null)
        {
            bool status = openSettings.activeSelf;
            openSettings.SetActive(!status);
        }
    }

    //This method ties the OnClick event handler to the "Quit" button to close out of the application
    public void Quit()
    {
        Application.Quit();
    }
}
