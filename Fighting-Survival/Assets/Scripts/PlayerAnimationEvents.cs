using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerAnimationEvents : MonoBehaviour
{
    public ThirdPersonUserControl Controller;
    public Collider CollisionCollider;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void EnableCollisionCollider()
    {
        CollisionCollider.enabled = true;
    }

    void EnablePlayerController()
    {
        if (!GameManager.Instance.IsPlayerDead())
        {
            Controller.enabled = true;
        }
    }

    void DesablePlayerController()
    {
        Controller.enabled = false;
    }
}
