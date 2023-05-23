using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript3 : MonoBehaviour
{
    public GameObject NPCDialog2;
    public Text NPCText2;

    void Start()
    {
        NPCDialog2 = GameObject.Find("NPCDialog2");
        NPCText2 = GameObject.Find("NPCText2").GetComponent<Text>();
        NPCDialog2.SetActive(false);
    }

    public void NPCChatEnter(string text)
    {
        
        NPCText2.text = text;
        NPCDialog2.SetActive(true);
    }

    public void NPCChatExit()
    {
        NPCText2.text = "";
        NPCDialog2.SetActive(false);
    }
}