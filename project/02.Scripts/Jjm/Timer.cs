using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public int timer = 0;

    private void Start()
    {
        timer = -4;
        StartCoroutine(TimerCoroution());
    }

    IEnumerator TimerCoroution()
    {
        timer += 1;
        if (timer >= 0)
        {
            timerText.text = "Timer : " + (timer / 60 % 60).ToString("D2") + " : " + (timer % 60).ToString("D2");
        }


        yield return new WaitForSeconds(1f);

        StartCoroutine(TimerCoroution());
    }
}