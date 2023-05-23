using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class DebuffControlJump : MonoBehaviour
{
    public void JumpDown(ThirdPersonController value)
    {
        StartCoroutine(Jumpx(value));
    }

    IEnumerator Jumpx(ThirdPersonController JumpDebuff)
    {
        Debug.Log("Jump Impossible");
        JumpDebuff.JumpHeight = 0;

        yield return new WaitForSecondsRealtime(5f);

        JumpDebuff.JumpHeight = 1.2f;
    }
}
