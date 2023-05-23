using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    /*public GameObject Timeorigin;*/ 
    private TextMeshProUGUI time;
    public float timeCount;

    // Start is called before the first frame update
    void Start()
    {
         time = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        timeCount = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        float min = Mathf.Floor(timeCount / 60);
        float sec = Mathf.RoundToInt(timeCount % 60);

        time.text = min+ " : " + sec;
    }
}
