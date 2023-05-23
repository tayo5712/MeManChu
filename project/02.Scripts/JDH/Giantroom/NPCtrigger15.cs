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
            GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().ChatText = "<size=25><color=#ff7777>[�ձ� �丮��]</color></size> �丮�� �ʿ��ϴٰ�? ��.. �� , �߰�⸦ �������ָ� ���ִ� �丮�� ���ٰ�!";
            Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        }

        else {
            ChatText = "<size=25><color=#ff7777>[����]</color></size> ��� �丮��!! ���� �̤� ���� ��� �����!";
            Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
            GameObject.Find("lastdoorlock").GetComponent<YellowKeycheck>().yellokey = 1;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}