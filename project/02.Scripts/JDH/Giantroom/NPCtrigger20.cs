using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;



public class NPCtrigger20 : MonoBehaviour
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
                ChatText = "<size=20><color=#ff7777>[System]</color></size> ��ȭ�� �ֿ����ϴ�!";
                
                Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
                GameObject.Find("cooperquest").GetComponent<NPCtrigger17>().ChatText = "<size=25><color=#ff7777>[�̻��� �����]</color></size> ��~~ ��ȭ�� �����Ա���! ��! �� �ٰ�!";
                GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().water = 1;
                coin = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("cooperquest").GetComponent<NPCtrigger17>().coopercoin = 1;

        coin = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}