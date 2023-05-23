using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtrigger2 : MonoBehaviour
{
    public string ChatText = "";
    private GameObject Main2;
    void Start()
    {
        Main2 = GameObject.Find("Main2");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Main2.GetComponent<MainScript2>().NPCChatEnter(ChatText);
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        Main2.GetComponent<MainScript2>().NPCChatExit();
        
    }
}