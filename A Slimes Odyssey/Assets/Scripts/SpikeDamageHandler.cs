using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamageHandler : MonoBehaviour
{
    [SerializeField] Slime slime;
    const int damage = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Tilemap")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            slime.SpikeDamage(damage);
        }
    }
}
