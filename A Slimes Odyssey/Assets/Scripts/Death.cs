using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        var slime = other.collider.GetComponent<Slime>();
        if(slime != null)
        {
            slime.Death();
        }
    }
}
