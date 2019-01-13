using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerWinningAnimation : MonoBehaviour
{
    Animator anim;
    ThirdPersonUserControl Controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Controller = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlayerWon())
        {
            anim.SetTrigger("Winning");
            Controller.enabled = false;
        }
    }
}
