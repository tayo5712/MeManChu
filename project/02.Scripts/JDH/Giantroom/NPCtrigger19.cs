using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;



public class NPCtrigger19 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
 

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }
    

    private void OnTriggerEnter(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("Questcharacter2").GetComponent<NPCtrigger14>().chicken = 1;

    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}