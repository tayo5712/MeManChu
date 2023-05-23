using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Portal_to_2 : MonoBehaviour
{
    /*
    bool IDCardChk = false;
    public void clickIDCard()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        GameObject obj = GameObject.Find("신분증");
        Vector3 position = obj.transform.localPosition;
        if (IDCardChk == false)
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1200);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 700);
            position.x = 0;
            position.y = 0;
            obj.transform.localPosition = position;
            IDCardChk = true;
        }
        else
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 470);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300);
            position.x = -580;
            position.y = 10;
            obj.transform.localPosition = position;
            IDCardChk = false;
        }
    }
    */
    public int washed = 0;

    private GameObject NPCDialog;
    private Text NPCText;


    private void OnTriggerEnter(Collider other)
    {
        if (washed == 1)
        {
            SceneManager.LoadScene("Fire_2");
            NPCDialog = GameObject.Find("NohandDialog");

            GameObject.Find("Portalto2").GetComponent<NPCtrigger>().ChatText = "<color=#ff7777>[메시지]</color> <size=20><color=#ffff33> CLEAR ! 2층으로 이동합니다 !</color></size>";
            NPCText = GameObject.Find("NohandText").GetComponent<Text>();
            NPCDialog.SetActive(true);
            
        }
        else {
            
            NPCDialog = GameObject.Find("NohandDialog");

            GameObject.Find("Portalto2").GetComponent<NPCtrigger>().ChatText = "<color=#ff7777>[메시지]</color> <size=20><color=#ffff33> 젖은 손수건이 필요합니다 ! </color></size>";
            NPCText = GameObject.Find("NohandText").GetComponent<Text>();
            NPCDialog.SetActive(true);
        }
    }

}
