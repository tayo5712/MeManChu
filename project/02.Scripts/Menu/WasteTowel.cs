using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WasteTowel : MonoBehaviour
{
    public int value;
    public string itemName;

    //hastool�� ������������
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
                    UiText.text = itemName + " ȹ�� �Ͻ÷���" + "<color=yellow>" + "(E)" + "</color>" + "Ű�� �����ּ���";
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
                    UiText.text = "�ռ����� ���� ì���ּ���";
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
