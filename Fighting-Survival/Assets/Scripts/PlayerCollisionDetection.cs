using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerCollisionDetection : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyHand") || other.CompareTag("EnemyRighFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("GotAHit");
            PlayerHealth.instance.SetHealth(-5);
        }
        if (other.CompareTag("EnemyLeftFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("knockdown");
            PlayerHealth.instance.SetHealth(-10);
            GetComponent<Collider>().enabled = false;
        }
    }
}
