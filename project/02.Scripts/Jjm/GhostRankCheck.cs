using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GhostRankCheck : MonoBehaviour
{
    [SerializeField]
    public GameObject Fire_rank;
    public TMP_Text content_text;
    public string target;
    public bool state;
    private string text_rank;

    private void Start()
    {
        StartCoroutine(update_Rank());
        Fire_rank.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        content_text.text = text_rank;
        Fire_rank.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Fire_rank.SetActive(false);
    }
    IEnumerator update_Rank()
    {
        text_rank = "";
        StartCoroutine(REST.getRanks_Map(target, callbackf, state));
        Debug.Log(text_rank);
        yield return new WaitForSeconds(60f);
        StartCoroutine(update_Rank());
    }
    public void callbackf(RESULT result)
    {
        //int obj_c = 2;
        int cnt = 1;
        Debug.Log("?????????????????????????????????????���Ⱑ �־ȵ�2222" + result);
        foreach (RANK rank in result.ranks)
        {
            for (int i = 0; i < 15 - rank.id.Length; i++) rank.id += " ";
            for (int i = 0; i < 15 - rank.name.Length; i++) rank.name += " ";
            string temp1 = $"{cnt++,5}   {rank.id,15}   {rank.name,13} {rank.time.Substring(3),8}    {rank.date.Substring(5, 5),8}";
            Debug.Log(temp1+ "?????????????????????????????????????���Ⱑ �־ȵ�");
            text_rank += temp1 + "\n";

        }
        return;
    }



}
