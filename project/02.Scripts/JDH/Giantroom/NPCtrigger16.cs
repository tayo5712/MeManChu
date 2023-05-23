using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCtrigger16 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int scoin = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (scoin == 1) { GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().chicken = 1; }

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}