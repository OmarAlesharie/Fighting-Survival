using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        if (other.CompareTag("EnemyLeftFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("knockdown");
        }
    }
}
