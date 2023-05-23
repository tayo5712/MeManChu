using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiztrigger1 : MonoBehaviour
{
    public string ChatText = "";
    public GameObject Main3;
    public int greenkey = 0;
    public GameObject Keypad;


    private void OnTriggerEnter(Collider other)
    {
        Keypad.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //other.GetComponent<StarterAssets.StarterAssetsInputs>().PauseMenu(true);
    }

    private void OnTriggerExit(Collider other)
    {

        Keypad.SetActive(false);
        ChatText = "";
        GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText = "";
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //other.GetComponent<StarterAssets.StarterAssetsInputs>().PauseMenu(true);
        GameObject.Find("NPCText3").GetComponent<Text>().text = "";
    }
}