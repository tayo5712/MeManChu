using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Run_startdoor : MonoBehaviour
{
    private TextMeshProUGUI count;
    private float TimeCount;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.FindWithTag("Crush"), 12f);
        count = GameObject.Find("startcount").GetComponent<TextMeshProUGUI>();
        TimeCount = 12f;
        

    }

    // Update is called once per frame
    void Update()
    {
        TimeCount -= Time.deltaTime;
        int ITimeCount = (int)TimeCount;
        if (ITimeCount > 0 && 6 > ITimeCount)
        {
        count.text = ITimeCount.ToString();
        }
        else
        {
            count.text = "";
        }

    }
}
