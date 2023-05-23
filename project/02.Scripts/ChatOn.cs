using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatOn : MonoBehaviour
{   
    public GameObject Chat;
    public GameObject InputText;
    public Button ChatButton;


    public void Start()
    {
        Chat.SetActive(true);
        InputText.SetActive(true);
    }
    public void ChatON()
    {   
        if (Chat.activeSelf == true)
        {
            Chat.SetActive(false);
            InputText.SetActive(false);
        }
        else
        {
            Chat.SetActive(true);
            InputText.SetActive(true);
        }
    }

}
