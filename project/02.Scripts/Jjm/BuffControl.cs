using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffControl : MonoBehaviour
{
    public void SpeedChange(ThirdPersonController value)
    {
        StartCoroutine(Speedup(value));
    }

    IEnumerator Speedup(ThirdPersonController MoveSpeedBuff)
    {
        Debug.Log("Buff");
        MoveSpeedBuff.MoveSpeed = 5f;
        MoveSpeedBuff.SprintSpeed = 5f;
        yield return new WaitForSecondsRealtime(3f);

        MoveSpeedBuff.MoveSpeed = 2f;
        MoveSpeedBuff.SprintSpeed = 3.5f;
        Debug.Log("Buff_fin");
    }
}
