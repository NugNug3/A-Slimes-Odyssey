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

    [Header ("Layering")]
    [SerializeField] LayerMask groundLayer;


    [Header ("Animation")]
    [SerializeField] private GameObject body;
    [SerializeField] private List<AnimationStateChanger> animationStatechangers;

    [Header ("Death")]
    [SerializeField] Collider2D deathCollider;
    [SerializeField] HealthHandler healthHandler;
    [SerializeField] GameOver gameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        deathCollider = GetComponent<Collider2D>();
        StartingPoint(transform.position);
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

    public void Jump()
    {
        if(Physics2D.OverlapCircleAll(transform.position, 2f, groundLayer).Length > 0)
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
            gameOver.GameOverScene();
        }
        activity = false;
        deathCollider.enabled = false;
        StartCoroutine(Respawn());
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
}
