using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtrigger11 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int greenkey;
    public GameObject NPCDialog;

    void Start()
    {
        Main3 = GameObject.Find("Main3");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("Padlock").GetComponent<Keycheck>().val = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        
         Main3.GetComponent<MainScript3>().NPCChatExit();
        GameObject.Find("Padlock").GetComponent<Keycheck>().val = 0;

    }
}