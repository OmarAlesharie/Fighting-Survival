using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionDetection : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent nav;
    public GameObject Enemy;

    private EnemyHealth enemyHealth;
    //private bool CanDelete;

    
    // Start is called before the first frame update
    void Start()
    {
        //CanDelete = false;
        enemyHealth = Enemy.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") || other.CompareTag("RightFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("GotAhit");
            enemyHealth.SetHealth(10);
        }
        if (other.CompareTag("LeftFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("knockdown");
            nav.enabled = false;
            enemyHealth.SetHealth(20);
        }
    }
}
