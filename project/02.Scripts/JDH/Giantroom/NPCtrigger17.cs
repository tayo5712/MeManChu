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
       // GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().ChatText = "<size=25><color=#ff7777>[�ձ� �丮��]</color></size> �丮�� �ʿ��ϴٰ�? ��.. ����, ��, ����� �������ָ� ���ִ� �丮�� ���ٰ�!";
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}