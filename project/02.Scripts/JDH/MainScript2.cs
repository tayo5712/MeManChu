using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript2 : MonoBehaviour
{
    private GameObject NPCDialog2;
    private Text NPCText2;

    void Start()
    {   
        
        NPCDialog2 = GameObject.Find("QuestDialog");
        NPCText2 = GameObject.Find("NPCText").GetComponent<Text>();
        
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