using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance = null;
    public Slider HealthSlider;

    private int Health;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

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
