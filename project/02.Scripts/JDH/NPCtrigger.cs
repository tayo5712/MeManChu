using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtrigger : MonoBehaviour
{
    public string ChatText = "";
    private GameObject Main;
    void Start()
    {
        Main = GameObject.Find("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        Main.GetComponent<MainScript>().NPCChatExit();
        
    }
}