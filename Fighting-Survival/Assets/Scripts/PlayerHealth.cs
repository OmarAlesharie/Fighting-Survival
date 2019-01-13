using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance = null;
    public Slider HealthSlider;
    public ThirdPersonUserControl PlayerController;

    private Animator anim;
    private int Health;
    private bool IsDead;

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
        anim = GetComponent<Animator>();
        IsDead = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    public void SetHealth(int damage)
    {
        Health += damage;
        UpdateHealthUI();
        if (Health <= 0) IsDead = true;
    }

    void PlayerIsdead()
    {
        if (IsDead)
        {
            PlayerController.enabled = false;
            anim.enabled = false;
        } 
    }

    void UpdateHealthUI()
    {
        HealthSlider.value = Health;
    }
}
