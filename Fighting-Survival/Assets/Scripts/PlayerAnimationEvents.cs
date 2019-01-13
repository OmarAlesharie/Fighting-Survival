using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerAnimationEvents : MonoBehaviour
{
    public ThirdPersonUserControl Controller;

    void EnablePlayerController()
    {
        if (!GameManager.Instance.IsPlayerDead())
        {
            Controller.enabled = true;
        }
    }
}
