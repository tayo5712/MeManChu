using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;



public class NPCtrigger18 : MonoBehaviour
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
                
               // Destroy(GameObject.Find("GoldCoins"));
                
                ChatText = "<size=20><color=#ff7777>[System]</color></size> 은화를 주웠습니다!";
                
                Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
                GameObject.Find("Questcharacter4").GetComponent<NPCtrigger16>().ChatText = "<size=25><color=#ff7777>[양계장 주인]</color></size> 은화를 가져왔구만. 닭고기 값은 잘 받았어. 가져가! ";
                Destroy(GameObject.Find("cwall"));
                Destroy(GameObject.Find("cwall2"));
                coin = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("Questcharacter4").GetComponent<NPCtrigger16>().scoin= 1;

        coin = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}