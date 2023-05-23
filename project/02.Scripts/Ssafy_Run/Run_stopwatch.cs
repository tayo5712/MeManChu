using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Run_stopwatch : MonoBehaviour
{
    public int time;
    public int deathcount;
    public TMP_Text timecount;
    public TMP_Text death;
    // Start is called before the first frame update
    void Start()
    {
        time = -12;
        deathcount = 0;
    /*    timecount = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        death = GameObject.Find("Death").GetComponent<TextMeshProUGUI>();*/
        StartCoroutine(TimerCoroution());
    }

    // Update is called once per frame
    void Update()
    {
        death.text = "¶³¾îÁø È½¼ö : " + deathcount;
    }
    IEnumerator TimerCoroution()
    {
        time += 1;
        if (time >= 0)
        {
        timecount.text = (time / 60).ToString("D2") + ":" + (time % 60).ToString("D2");
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(TimerCoroution());
    }
}
