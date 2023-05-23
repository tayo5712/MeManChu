using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtrigger10 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int bkey;
    void Start()
    {
        Main3 = GameObject.Find("Main3");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);

        bkey = GameObject.Find("Bluekey").GetComponent<Bluekey>().bluekey;

        if (bkey == 1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Destroy(GameObject.Find("1FCube2"));
                Destroy(GameObject.Find("DoorLock"));
                Destroy(GameObject.Find("1Door"));
                Destroy(GameObject.Find("questionmarkb"));
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
       

    }
}