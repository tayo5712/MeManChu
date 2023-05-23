using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffControlJump : MonoBehaviour
{
    public void JumpHigh(ThirdPersonController value)
    {
        StartCoroutine(Jumpup(value));
    }

    IEnumerator Jumpup(ThirdPersonController JumpBuff)
    {
        Debug.Log("JumpBuff");
        JumpBuff.JumpHeight = 4f;

        yield return new WaitForSecondsRealtime(3f);

        JumpBuff.JumpHeight = 1.2f;
        Debug.Log("JumpFin");
    }
}
