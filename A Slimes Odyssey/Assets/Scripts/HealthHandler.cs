using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{

    [SerializeField] float startingHealth = 6f;
    public float currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        //TO DO - add damage animations (if time allows)
    }

    public float CheckHealth()
    {
        return currentHealth;
    }

}
