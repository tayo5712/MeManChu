using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffControlSlow : MonoBehaviour
{
    public void SpeedSlow(ThirdPersonController value)
    {
        StartCoroutine(SpeedDown(value));
    }

    IEnumerator SpeedDown(ThirdPersonController SlowDebuff)
    {
        Debug.Log("SlowDebuff");
        SlowDebuff.MoveSpeed = 0.5f;
        SlowDebuff.SprintSpeed = 0.5f;

        yield return new WaitForSecondsRealtime(5f);

        SlowDebuff.MoveSpeed = 2f;
        SlowDebuff.SprintSpeed = 3.5f;
    }
}
