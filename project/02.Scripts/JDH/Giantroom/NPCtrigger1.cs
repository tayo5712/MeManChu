using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCtrigger1 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int greenkey = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("Padlock").GetComponent<NPCtrigger11>().greenkey = 1;
        Destroy(GameObject.Find("Greenkey"));
        Destroy(GameObject.Find("questionmarkg"));
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        
    }
}