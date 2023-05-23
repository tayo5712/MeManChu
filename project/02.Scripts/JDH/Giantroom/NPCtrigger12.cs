using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCtrigger12 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int gold = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);

        if (gold == 1) {
            Destroy(GameObject.Find("Keyboxprotect"));
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}