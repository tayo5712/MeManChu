using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControll : MonoBehaviour
{
    public void SpeedChange(ThirdPersonController value)
    {
        /*StopCoroutine(Speedup(value));*/
        StartCoroutine(Speedup(value));
    }

    IEnumerator Speedup(ThirdPersonController speedControl)
    {
        Debug.Log("SpeedUp");
        speedControl.MoveSpeed = 10f;
        speedControl.SprintSpeed = 10f;
        speedControl.JumpHeight = 10f;
        yield return new WaitForSecondsRealtime(10f);

        speedControl.MoveSpeed = 2f;
        speedControl.SprintSpeed = 5.335f;
        speedControl.JumpHeight = 1.2f;
        Debug.Log("SpeedDown");
    }
}
