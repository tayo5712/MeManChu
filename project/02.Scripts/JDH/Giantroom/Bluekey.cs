using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bluekey : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int bluekey = 0;

    void Start()
    {
        Main3 = GameObject.Find("Main3");

    }

    private void OnTriggerEnter(Collider other)
    {
        Main3.GetComponent<MainScript3>().NPCChatEnter(ChatText);
        GameObject.Find("DoorLock").GetComponent<BlueKeycheck>().bluekey = 1;
       // GameObject.Find("Bluekey").SetActive(false);

    }

    private void OnTriggerExit(Collider other)
    {

        Main3.GetComponent<MainScript3>().NPCChatExit();
        //GameObject.Find("NPCDialog2").SetActive(false);
        GameObject.Find("NPCText2").GetComponent<Text>().text = "";

    }
}