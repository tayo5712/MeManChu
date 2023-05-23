using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BYTRIG : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public TMP_Text Text;
    public int gold = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // 서버-db에서 랭킹 기록을 가져오는데

       //tartCoroutine(REST.getRanks_Map("1", Text));
        Main3.GetComponent<MainScript4>().NPCChatEnter(ChatText);

    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript4>().NPCChatExit();
        
    }
}