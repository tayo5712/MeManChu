using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GotoFloorTwo : MonoBehaviour
{
    //�÷��̾� ���� ���빰 ��������
    private GameObject user;
    private Transform PlayerTransForm;
    private ItemInputSystem ItemInputSystem;

    //���� ���� UI
    public TMP_Text actionT;

/*    private void Start()
    {
        user = GameObject.FindWithTag("user");
        textMeshPro = GameObject.Find(user.name + "/Canvas/actionText").GetComponent<TMP_Text>();
        Debug.Log(textMeshPro.text);
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerTransForm= other.GetComponent<Transform>();
            ItemInputSystem= other.GetComponent<ItemInputSystem>();
            if (ItemInputSystem.hasTools[3])
            {
                PlayerTransForm.position = new Vector3(15.68f,23.94189f, 11.734f);
                
                SceneManager.LoadScene("Fire_2");
            }
            else
            {
                actionT.text = "���� �ռ����� �ʿ��մϴ�";
                actionT.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        actionT.gameObject.SetActive(false);    
    }
}
