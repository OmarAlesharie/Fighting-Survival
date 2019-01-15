using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionDetection : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent nav;
    public GameObject Enemy;

    public AudioClip[] Punches;
    public AudioClip[] Kickes;

    private AudioSource enemyFxSource;

    private EnemyHealth enemyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyFxSource = GetComponent<AudioSource>();
        enemyHealth = Enemy.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") || other.CompareTag("RightFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            if (other.CompareTag("PlayerHand"))
            {
                enemyFxSource.clip = Punches[Random.Range(0, Punches.Length)];
                if (!enemyFxSource.isPlaying)
                {
                    enemyFxSource.Play();
                }
            }
            if (other.CompareTag("RightFoot"))
            {
                enemyFxSource.clip = Kickes[Random.Range(0, Kickes.Length)];
                if (!enemyFxSource.isPlaying)
                {
                    enemyFxSource.Play();
                }
            }

            anim.SetTrigger("GotAhit");
            enemyHealth.SetHealth(10);
        }
        if (other.CompareTag("LeftFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            if (other.CompareTag("LeftFoot"))
            {
                enemyFxSource.clip = Kickes[Random.Range(0, Kickes.Length)];
                if (!enemyFxSource.isPlaying)
                {
                    enemyFxSource.Play();
                }
            }

            anim.SetTrigger("knockdown");
            nav.enabled = false;
            enemyHealth.SetHealth(20);
        }
    }
}
