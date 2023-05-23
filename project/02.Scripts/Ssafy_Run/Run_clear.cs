using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Run_clear : MonoBehaviour
{
    private GameObject exit;
    private float runtime;
    private TextMeshProUGUI cleartime;
    private bool Goal = false;
    private int death;
    // Start is called before the first frame update
    private void Awake()
    {
        exit = GameObject.Find("Panel");
    }
    private void Start()
    {   
        exit.SetActive(false);
    }

    string getSec(float sec) {

        return sec > 9 ? sec.ToString() : $"0{sec}";
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (Goal == false)
        {
        exit.SetActive(true);
        cleartime = GameObject.Find("ClearTime").GetComponent<TextMeshProUGUI>();
        runtime = GameObject.Find("Plane").GetComponent<Run_stopwatch>().time;
        death = GameObject.Find("Plane").GetComponent<Run_stopwatch>().deathcount;
        float min = Mathf.Floor(runtime / 59);
        float sec = Mathf.RoundToInt(runtime % 59);
        cleartime.text = "°æ°ú ½Ã°£ : " + min + "ºÐ" + sec + "ÃÊ" +" " + "¶³¾îÁø È½¼ö : " + death;
        Goal= true;

        string id = PlayerPrefs.GetString("ID").ToString();
        string name = PlayerPrefs.GetString("NAME").ToString();
        string map = "ssafyRun"; // ¸Ê ÀÌ¸§
        string time = $"00:{min.ToString()}:{getSec(sec)}";
        StartCoroutine(REST.postRankIns(new RANK(id, name, map, time)));
        }

    }
}
