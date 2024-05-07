using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] Slime slime;
    void OnCollisionEnter2D(Collision2D other)
    {
        var slime = other.collider.GetComponent<Slime>();
        if(other.gameObject.name == "Death")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        if(slime != null)
        {
            slime.Death();
        }
    }
}
