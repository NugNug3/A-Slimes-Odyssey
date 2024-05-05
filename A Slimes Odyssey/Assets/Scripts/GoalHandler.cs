using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour
{
    [SerializeField] ScreenFader screenFader;
    public void OnTriggerEnter2D(Collider2D other)
    {
        //play melt animation, change scene to the next level
    }
}
