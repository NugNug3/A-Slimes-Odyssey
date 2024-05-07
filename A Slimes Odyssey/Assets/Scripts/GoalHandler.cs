using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour
{
    [SerializeField] ScreenFader screenFader;
    [SerializeField] Slime slime;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Tilemap")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        //TO DO: play melt animation, change scene to the next level
        else
        {
            CoinCounter.finalCoinSingletonValue = CoinCounter.coinSingleton.ShowCoins();
            slime.PlayGoalAnimation("melt");
            StartCoroutine(WaitForAnim());
            IEnumerator WaitForAnim()
            {
                yield return new WaitForSeconds(2f);
                screenFader.FadeToColor("Win");
            }
        }
    }
}
