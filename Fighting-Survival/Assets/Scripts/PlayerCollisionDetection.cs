using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerCollisionDetection : MonoBehaviour
{
    public Animator anim;

    public AudioClip[] Punches;
    public AudioClip[] Kickes;
    
    private AudioSource playerFxSource;

    private void Start()
    {
        playerFxSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyHand") || other.CompareTag("EnemyRighFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            if (other.CompareTag("EnemyHand"))
            {
                playerFxSource.clip = Punches[Random.Range(0, Punches.Length)];
                if (!playerFxSource.isPlaying)
                {
                    playerFxSource.Play();
                }
            }
            if (other.CompareTag("EnemyRighFoot"))
            {
                playerFxSource.clip = Kickes[Random.Range(0, Kickes.Length)];
                if (!playerFxSource.isPlaying)
                {
                    playerFxSource.Play();
                }
            }
            anim.SetTrigger("GotAHit");
            PlayerHealth.instance.SetHealth(-5);
        }
        if (other.CompareTag("EnemyLeftFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            if (other.CompareTag("EnemyLeftFoot"))
            {
                playerFxSource.clip = Kickes[Random.Range(0, Kickes.Length)];
                if (!playerFxSource.isPlaying)
                {
                    playerFxSource.Play();
                }
            }

            anim.SetTrigger("knockdown");
            PlayerHealth.instance.SetHealth(-10);
            GetComponent<Collider>().enabled = false;
        }
    }
}
