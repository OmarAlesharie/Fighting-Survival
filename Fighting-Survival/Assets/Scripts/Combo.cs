using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Combo : MonoBehaviour
{
    
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
        if (Input.GetButtonDown("Fire1"))
        {
            Fire1Count++;
            if (!isDoingComboMove)
            {
                DoComboAttack();
            } 
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Fire1Count = 0;
            anim.SetInteger("combo", 8);
            isDoingComboMove = true;
        }

        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            cancleCombo();
        }

        if (Input.GetAxis("Vertical") != 0.0f)
        {
            cancleCombo();
        }

    }

    public void CheckForNextAnimation()
    {
        if (Fire1Count > 0)
        {
            isDoingComboMove = false;
            DoComboAttack();
        }
        else
        {
            cancleCombo();
        }
    }

    private void cancleCombo()
    {
        anim.SetInteger("combo", 0);
        combostage = 0;
        isDoingComboMove = false;
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
                anim.SetInteger("combo", 1);
                combostage++;
                isDoingComboMove = true;
                break;
            case 1:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 2);
                    combostage++;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
            case 2:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 3);
                    combostage++;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
            case 3:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 4);
                    combostage++;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
            case 4:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 5);
                    combostage++;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
            case 5:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 6);
                    combostage++;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
            case 6:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 7);
                    combostage++;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
            case 7:
                if (Fire1Count > 0)
                {
                    Fire1Count = 0;
                    anim.SetInteger("combo", 8);
                    combostage = 0;
                    isDoingComboMove = true;
                }
                else
                {
                    cancleCombo();
                }
                break;
        }
    }
}
