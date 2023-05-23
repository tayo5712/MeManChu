using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCtrigger17 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int coopercoin = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (coopercoin == 1) {
            GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().water = 1;
        
        }
       // GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().ChatText = "<size=25><color=#ff7777>[왕궁 요리사]</color></size> 요리가 필요하다고? 흠.. 감자, 물, 계란을 가져다주면 맛있는 요리를 해줄게!";
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}