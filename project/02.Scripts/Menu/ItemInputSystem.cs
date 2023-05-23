using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemInputSystem : MonoBehaviour
{
    // ĳ���� �κ��丮
    public GameObject[] Tools;
    public bool[] hasTools = new bool[5];
    public GameObject antiFire;

    public TMP_Text actionText; // �ൿ�� ���� �� �ؽ�Ʈ
    private GameObject nearObject;

    //������ ���
    private EquipItem EquipTool;

    // ��� �������ΰ�

    private int equipItem;

    private Animator animator;

    private void Start()
    {
        equipItem = -1;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
           
        Swap();
        AttackTools();
    }

    void InterationCheck()
    {
        Debug.Log("eŰ�� ���Ƚ��ϴ�.");

        Debug.Log("�ֺ��������� ���� �Դϴ�.");
        Items items = nearObject.GetComponent<Items>();
        int ToolsIndex = items.value;
        Debug.Log(ToolsIndex);
        hasTools[ToolsIndex] = true;

        Destroy(nearObject);

        actionText.gameObject.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tools")
        {
            actionText.gameObject.SetActive(true);
            nearObject = other.gameObject;
            Items items = nearObject.GetComponent<Items>();
            string ToolName = items.itemName;
            actionText.text = ToolName + " ȹ�� �Ͻ÷���" + "<color=yellow>" + "(E)" + "</color>" + "Ű�� �����ּ���";
            Debug.Log("123451234512345555555");
            if (Input.GetKey(KeyCode.E))
            {
                InterationCheck();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tools")
        {
            actionText.gameObject.SetActive(false);
        }
    }

    private void Swap()
    {   
        if (hasTools[0])
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (equipItem != 0)
                {
                    equipItem = 0;
                    //������ ���� Ȱ��ȭ
                    Tools[1]?.SetActive(false);
                    //Tools[2]?.SetActive(false);
                    Tools[equipItem].SetActive(true);
                    EquipTool = Tools[equipItem].GetComponent<EquipItem>();
                    //���� �ִϸ��̼� Ȱ��ȭ
                    animator.SetTrigger("doSwap");
                }
                else
                {
                    animator.SetTrigger("doUnswap");
                    Tools[equipItem].SetActive(false);
                    equipItem = -1;
                }
            }
        }
        if (hasTools[1])
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (equipItem != 1)
                {
                    equipItem = 1;
                    //������ ���� Ȱ��ȭ
                    Tools[equipItem].SetActive(true);
                    Tools[0]?.SetActive(false);
                    //Tools[2]?.SetActive(false);
                    EquipTool = Tools[equipItem].GetComponent<EquipItem>();
                    //���� �ִϸ��̼� Ȱ��ȭ
                    animator.SetTrigger("doSwap");
                }
                else
                {
                    animator.SetTrigger("doUnswap");
                    Tools[equipItem].SetActive(false);
                    equipItem = -1;
                }
            }
        }
    }

    private void AttackTools()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click.");
            if (equipItem == 0)
            {
                EquipTool.Use();
                animator.SetTrigger("doAttack");
            }
            if (equipItem == 1)
            {
                EquipTool.Use();
                animator.SetBool("doFire", true);
                antiFire.SetActive(true);
                BoxCollider boxCollider  = antiFire.GetComponent<BoxCollider>();
                StopCoroutine(FireUpdate(boxCollider));
                StartCoroutine(FireUpdate(boxCollider));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("doFire", false);
            antiFire.SetActive(false);
        }
    }

    IEnumerator FireUpdate(BoxCollider value)
    {
        value.enabled = true;
        yield return new WaitForSeconds(1f);
        value.enabled= false;
        yield return new WaitForSeconds(0.1f);
        value.enabled = true;

    }
}

