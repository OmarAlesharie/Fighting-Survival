using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionDetection : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent nav;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") || other.CompareTag("RightFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("GotAhit");
        }
        if (other.CompareTag("LeftFoot"))
        {
            anim.enabled = false;
            anim.enabled = true;

            anim.SetTrigger("knockdown");
            nav.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
