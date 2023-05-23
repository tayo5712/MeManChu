using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{
    private GameObject fin;
    private GameObject curTime;
    private GameObject finTime;
    GameObject player;
    private TextMeshProUGUI endTime;
    private float runnigTime;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fin = GameObject.Find("MenuCanvas");
        curTime = GameObject.Find("TimerText");
        finTime = GameObject.Find("FinTime");


    }

    private void Start()
    {
        fin.SetActive(false);
    }

    string getSec(float sec)
    {
        return sec > 9 ? sec.ToString() : $"0{sec}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            fin.SetActive(true);
            curTime.SetActive(false);

            endTime = finTime.GetComponent<TextMeshProUGUI>();
            runnigTime = curTime.GetComponent<Timer>().timer;

            float min = Mathf.Floor(runnigTime / 59);
            float sec = Mathf.RoundToInt(runnigTime % 59);

            endTime.text = "버틴시간 : " + min + " 분 " + getSec(sec) + " 초 !!!";

            string id = PlayerPrefs.GetString("ID").ToString();
            string name = PlayerPrefs.GetString("NAME").ToString();
            string map = "skyStair"; // 맵 이름
            string time = getSec(sec);
            StartCoroutine(REST.postRankIns(new RANK(id, name, map, time)));
        }
    }
}
