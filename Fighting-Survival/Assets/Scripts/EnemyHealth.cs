using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider HealthSlider;

    private int Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    public void SetHealth(int damage)
    {
        Health -= damage;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        HealthSlider.value = Health;
    }
}
