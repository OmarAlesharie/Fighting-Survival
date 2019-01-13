using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider HealthSlider;

    private Animator anim;
    private int Health;
    private bool EnemyIsDead;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        EnemyIsDead = false;
        anim = GetComponent<Animator>();
    }

    public void SetHealth(int damage)
    {
        Health -= damage;
        UpdateHealthUI();
        CheckIfDead();
    }

    public int GetHealth()
    {
        return Health;
    }

    void CheckIfDead()
    {
        if (Health <= 0)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("knockdown_loop_A"))
            {
                EnemyIsDead = true;
            }
            else
            {
                anim.enabled = false;
                anim.enabled = true;
                anim.SetTrigger("knockdown");
                EnemyIsDead = true;
            }
        }
    }

    void RemoveIfDead()
    {
        if (EnemyIsDead)
        {
            Destroy(gameObject);
        } 
    }

    void UpdateHealthUI()
    {
        HealthSlider.value = Health;
    }
}
