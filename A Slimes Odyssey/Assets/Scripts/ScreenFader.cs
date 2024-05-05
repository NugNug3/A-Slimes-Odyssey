using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScreenFader : MonoBehaviour
{
    [SerializeField] Image fader;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] Color fadeColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        FadeToClear();
    }

    void FadeToClear()
    {
        fader.color = fadeColor;
        StartCoroutine(FadeToClearRoutine());
        IEnumerator FadeToClearRoutine()
        {
            float timer = 0;
            while(timer < fadeTime)
            {
                yield return null;
                timer += Time.deltaTime;
                fader.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f - (timer/fadeTime));
            }
            fader.color = Color.clear;
        }
    }

    public void FadeToColor(string newScene = "")
    {
        fader.color = Color.clear;
        StartCoroutine(FadeToColorRoutine());
        IEnumerator FadeToColorRoutine()
        {
            float timer = 0;
            while(timer < fadeTime)
            {
                yield return null;
                timer += Time.deltaTime;
                fader.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, (timer/fadeTime));
            }
            fader.color = fadeColor;
            if(newScene != "")
            {
                SceneManager.LoadScene(newScene);
            }
        }
    }

}
