using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCtrigger15 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int npcmeet = 0;
    public int food = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (food == 0)
        {
            GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().ChatText = "<size=25><color=#ff7777>[왕궁 요리사]</color></size> 요리가 필요하다고? 흠.. 물 , 닭고기를 가져다주면 맛있는 요리를 해줄게!";
            Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        }

        else {
            ChatText = "<size=25><color=#ff7777>[래퍼]</color></size> 우와 요리다!! 고마워 ㅜㅜ 여기 노랑 열쇠야!";
            Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
            GameObject.Find("lastdoorlock").GetComponent<YellowKeycheck>().yellokey = 1;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}