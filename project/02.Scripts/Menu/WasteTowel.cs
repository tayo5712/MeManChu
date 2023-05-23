using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WasteTowel : MonoBehaviour
{
    public int value;
    public string itemName;

    //hastool을 가져오기위한
    private ItemInputSystem Player;
    private TMP_Text UiText;
    private bool[] userTools = new bool[5];

    private void OnTriggerStay(Collider other)
    {   
        
        if (other.tag == "Player")
        {
            Debug.Log(itemName);
            Player = other.GetComponentInChildren<ItemInputSystem>();
            UiText = Player.actionText;
            if (!Player.hasTools[3]) 
            { 
                if (Player.hasTools[4])
                {
                    UiText.gameObject.SetActive(true);
                    UiText.text = itemName + " 획득 하시려면" + "<color=yellow>" + "(E)" + "</color>" + "키를 눌러주세요";
                  if (Input.GetKey(KeyCode.E))
                    {
                        Player.hasTools[3] = true;
                        Player.hasTools[4] = false;
                        UiText.gameObject.SetActive(false);
                    }

                }
                else
                {
                    UiText.gameObject.SetActive(true);
                    UiText.text = "손수건을 먼저 챙겨주세요";
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UiText.gameObject.SetActive(false);
        }
    }
}
