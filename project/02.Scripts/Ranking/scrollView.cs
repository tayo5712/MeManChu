using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class scrollView : MonoBehaviour
{
    public TMP_Text text_rank;
    public scrollView sv;


    private float sapce_cell = 4.0f;

    private Vector2 before_cell_vector2;
    public string target;
    public bool state;
    // 시간이 낮을수록 1등이면 state = true
    // 시간이 클수록 1등이면 state = false
    private void Start()
    {
/*        StopCoroutine(REST.getRanks_Map(target, callbackf, state));
        StartCoroutine(REST.getRanks_Map(target, callbackf, state));*/
    }
    private void Update()
    {
        Debug.Log(text_rank.text);

        if (text_rank.text == null) 
        {
            Debug.Log("랭킹매기기 스타트고스트");
            //StartCoroutine(REST.getRanks_Map(target, callbackf, state));
            StartCoroutine(update_Rank());
        }
    }
    public void callbackf(RESULT result)
    {
        //int obj_c = 2;
        int cnt = 1;

        foreach (RANK rank in result.ranks)
        {
            for (int i = 0; i < 15 - rank.id.Length; i++) rank.id += " ";
            for (int i = 0; i < 15 - rank.name.Length; i++) rank.name += " ";
            string temp1 = $"{cnt++,5}   {rank.id,15}   {rank.name,13} {rank.time.Substring(3),8}    {rank.date.Substring(5, 5),8}";
            text_rank.text += temp1 + "\n";

        }
        return;
    }

    IEnumerator update_Rank()
    {
        text_rank.text = null;
        StartCoroutine(REST.getRanks_Map(target, callbackf, state));
        yield return new WaitForSeconds(60f);
        StartCoroutine(update_Rank());
    }
}
