using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class CountDown_2 : MonoBehaviour
{
    private TextMeshProUGUI time;
    public float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        float min = Mathf.Floor(timeCount / 60);
        float sec = Mathf.RoundToInt(timeCount % 60);

        time.text = min + " : " + sec;
    }
}
