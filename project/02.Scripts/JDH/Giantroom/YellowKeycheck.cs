using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;



public class YellowKeycheck : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int yellokey = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");

    }
    private void Update()
    {
        if (yellokey == 1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                ChatText = "<size=20><color=#ff7777>[System]</color></size> 노랑 열쇠로 문을 열었습니다!";

                Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
                Destroy(GameObject.Find("lastdoorlock"));
                Destroy(GameObject.Find("ddodor"));
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        
        
    }

    private void OnTriggerExit(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatExit();

    }
}