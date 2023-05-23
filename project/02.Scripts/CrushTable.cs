using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrushTable : MonoBehaviour
{
    private ItemInputSystem _inputSystem;
    private GameObject _crush;
    public TMP_Text actionText;

    private void Start()
    {
        _crush = GameObject.FindWithTag("Crush");
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "axe")
        {
            Debug.Log("���ݴ��޴�");
            _crush.GetComponent<Renderer>().material.color = Color.red;
            Destroy(_crush, .7f);
        }

        if (other.tag == "Player")
        {
            _inputSystem = other.GetComponent<ItemInputSystem>();
            if (_inputSystem.hasTools[0])
            {
                actionText.gameObject.SetActive(true);
                actionText.text = "1���� ���� ���⸦ �����ϰ� ��Ŭ���� ���� �ּ���";
            }
            else
            {
                actionText.text = "������ �ʿ��մϴ�.";
                actionText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "axe")
        {
            Debug.Log("���ݴ��޴�");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        actionText.gameObject.SetActive(false);
    }
}
