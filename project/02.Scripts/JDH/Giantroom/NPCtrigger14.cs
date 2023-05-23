using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCtrigger14 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int npcmeet = 0;
    public int chicken = 0;
    public int water = 0;
    

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (chicken == 1 && water == 1) {
            GameObject.Find("Questcharacter3").GetComponent<NPCtrigger15>().food = 1;
            ChatText = "<size=25><color=#ff7777>[�ձÿ丮��]</color></size> ���� �߰�ⱸ��! ���� �丮�� �ٰ�!! ";
        }

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}