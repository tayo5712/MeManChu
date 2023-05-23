using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using StarterAssets;

public class Floor3Quest : MonoBehaviour
{
    // ����Ʈ �̿Ϸ� �Ϸ� �̹���
    public GameObject Quest1N;
    public GameObject Quest1Y;
    public GameObject Quest2N;
    public GameObject Quest2Y;

    // �÷��̾� ������Ʈ
    public GameObject Player;
    public ItemInputSystem PlayerItems;
    public bool findPlayer = false;
    private bool hasTowel = false;


    private void Update()
    {
        if (!findPlayer)
        {
            return;
        }
        //PlayerItems = Player.GetComponent<ItemInputSystem>();
        if (PlayerItems.hasTools[4])
        {
            Quest1Y.SetActive(true);
            hasTowel= true;
            Quest1N.SetActive(false);
        }
        
        if (hasTowel)
        {
            if (PlayerItems.hasTools[3])
            {
                Quest2Y.SetActive(true);
                Quest2N.SetActive(false);
            }
        }
    }
    
}
