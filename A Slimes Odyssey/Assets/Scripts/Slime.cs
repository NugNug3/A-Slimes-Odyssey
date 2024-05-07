using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header ("Basic Necessities")]
    Vector2 respawn;

    [Header ("Movement")]
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 20;
    [SerializeField] bool activity = true;
    Rigidbody2D rigidBody;
    [SerializeField] BoxCollider2D feet;

    [Header ("Layering/UI")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] ScreenFader screenFader;


    [Header ("Animation")]
    [SerializeField] private GameObject body;
    [SerializeField] private List<AnimationStateChanger> animationStatechangers;
    [SerializeField] bool goalState = false;

    [Header ("Death")]
    [SerializeField] CapsuleCollider2D deathCollider;
    [SerializeField] HealthHandler healthHandler;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        deathCollider = GetComponent<CapsuleCollider2D>();
        StartingPoint(transform.position);
        feet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!activity)
        {
            return;
        }
    }

    public void MoveSlime(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.velocity = (currentVelocity) + (direction * speed);
        if(rigidBody.velocity.x < 0)
        {
            body.transform.localScale = new Vector3(-1, 1, 1);
        }

        else if(rigidBody.velocity.x > 0)
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        if(goalState == false)
        {
            if(direction.x != 0)
            {
                foreach(AnimationStateChanger asc in animationStatechangers)
                {
                    asc.ChangeAnimationState("Walk");
                }
            }
            else
            {
                foreach(AnimationStateChanger asc in animationStatechangers)
                {
                        asc.ChangeAnimationState("Idle");
                }    
            }
        }  
    }

    public void PlayGoalAnimation(string animationName)
    {
        goalState = true;
        foreach(AnimationStateChanger asc in animationStatechangers)
        {
                asc.ChangeAnimationState(animationName);
        }
    }

    public void Jump()
    {
        if(feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            foreach(AnimationStateChanger asc in animationStatechangers)
            {
                asc.ChangeAnimationState("Jump");
            }

        }
    }

    public void Death() 
    {
        healthHandler.Damage(1);
        if(healthHandler.CheckHealth() < 1f)
        {
            CoinCounter.finalCoinSingletonValue = CoinCounter.coinSingleton.ShowCoins();
            screenFader.FadeToColor("GameOver");
        }
        activity = false;
        deathCollider.enabled = false;
        StartCoroutine(Respawn());
    }

    public void SpikeDamage(int damage)
    {
        healthHandler.Damage(damage);
        if(healthHandler.CheckHealth() < 1f)
        {
            goalState = true;
            StartCoroutine(WaitAnim());
            IEnumerator WaitAnim()
            {
                CoinCounter.finalCoinSingletonValue = CoinCounter.coinSingleton.ShowCoins();
                foreach(AnimationStateChanger asc in animationStatechangers)
                {
                    asc.ChangeAnimationState("melt");
                }
                yield return new WaitForSeconds(2f);
                screenFader.FadeToColor("GameOver");
            }
        }
    }
    
    public void StartingPoint(Vector2 position)
    {
        respawn = position;
    }

    IEnumerator Respawn() 
    {
        yield return new WaitForSeconds(1f);
        transform.position = respawn;
        activity = true;
        deathCollider.enabled = true;
    }

    public void PickupCoin()
    {
        CoinCounter.coinSingleton.AddCoin();
        GetComponent<AudioSource>().Play();
    }
}
