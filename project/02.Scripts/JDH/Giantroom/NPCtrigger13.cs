using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;



public class NPCtrigger13 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int coin = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }
    private void Update()
    {
        if (coin == 1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                GameObject.Find("Questcharacter").GetComponent<NPCtrigger12>().ChatText = "<size=25><color=#ff7777>[불량배]</color></size> 금화구만!! 좋아! 초록 열쇠를 가져가! ";
                
                ChatText = "<size=20><color=#ff7777>[System]</color></size> 금화를 주웠습니다!";
                
                Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
                

                coin = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("Questcharacter").GetComponent<NPCtrigger12>().gold = 1;

        coin = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}