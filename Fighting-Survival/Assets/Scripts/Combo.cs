using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Combo : MonoBehaviour
{
    public Collider PlayerRightHand;
    public Collider PlayerLiftHand;
    public Collider PlayerRightFoot;
    public Collider PlayerLiftFoot;

    public Collider CollisionCollider;

    private Animator anim;
    private int combostage;
    private int Fire1Count;
    private bool isDoingComboMove;

    
    // Start is called before the first frame update
    void Start()
    {
        Fire1Count = 0;
        combostage = 0;
        isDoingComboMove = false;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlayerWon())
        {
            return;
        }
        if (GameManager.Instance.IsPlayerDead())
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Fire1Count++;
            if (!isDoingComboMove)
            {
                CollisionCollider.enabled = true;
                anim.enabled = false;
                anim.enabled = true;
                DoComboAttack();
            } 
        }

        if (Input.GetButtonDown("Fire2"))
        {
            CollisionCollider.enabled = true;
            anim.enabled = false;
            anim.enabled = true;
            EnableColliders(true);
            Fire1Count = 0;
            anim.SetInteger("combo", 8);
            isDoingComboMove = true;
        }

        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            CancleCombo();
        }

        if (Input.GetAxis("Vertical") != 0.0f)
        {
            CancleCombo();
        }

    }

    void EnableColliders(bool status)
    {
        PlayerRightHand.enabled = status;
        PlayerLiftHand.enabled = status;
        PlayerRightFoot.enabled = status;
        PlayerLiftFoot.enabled = status;
    }

    private void CheckForNextAnimation()
    {
        EnableColliders(false);
        if (Fire1Count > 0)
        {
            isDoingComboMove = false;
            DoComboAttack();
        }
        else
        {
            CancleCombo();
        }
    }

    private void CancleCombo()
    {
        Fire1Count = 0;
        anim.SetInteger("combo", 0);
        combostage = 0;
        isDoingComboMove = false;
    }

    private void ResetAnimationTriggers()
    {
        anim.ResetTrigger("GotAHit");
        anim.ResetTrigger("knockdown");
    }

    void DoComboAttack()
    {
        if (isDoingComboMove)
        {
            return;
        }

        switch (combostage)
        {
            case 0:
                Fire1Count = 0;
                EnableColliders(true);
                anim.SetInteger("combo", 1);
                combostage++;
                isDoingComboMove = true;
                ResetAnimationTriggers();
                break;
            case 1:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 2);
                    combostage++;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
            case 2:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 3);
                    combostage++;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
            case 3:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 4);
                    combostage++;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
            case 4:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 5);
                    combostage++;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
            case 5:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 6);
                    combostage++;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
            case 6:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 7);
                    combostage++;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
            case 7:
                if (Fire1Count > 0)
                {
                    EnableColliders(true);
                    Fire1Count = 0;
                    anim.SetInteger("combo", 8);
                    combostage = 0;
                    isDoingComboMove = true;
                    ResetAnimationTriggers();
                }
                else
                {
                    CancleCombo();
                }
                break;
        }
    }
}
