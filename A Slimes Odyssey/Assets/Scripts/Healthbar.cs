using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    [SerializeField] HealthHandler slimeHealth;
    [SerializeField] Image totalHealthbar;
    [SerializeField] Image currentHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthbar.fillAmount = slimeHealth.currentHealth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = slimeHealth.currentHealth / 3;
    }
}
