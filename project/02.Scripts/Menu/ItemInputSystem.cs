using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemInputSystem : MonoBehaviour
{
    // 캐릭터 인벤토리
    public GameObject[] Tools;
    public bool[] hasTools = new bool[5];
    public GameObject antiFire;

    public TMP_Text actionText; // 행동을 보여 줄 텍스트
    private GameObject nearObject;

    //착용중 장비
    private EquipItem EquipTool;

    // 장비 착용중인가

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
        Debug.Log("e키가 눌렸습니다.");

        Debug.Log("주변아이템이 도구 입니다.");
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
            actionText.text = ToolName + " 획득 하시려면" + "<color=yellow>" + "(E)" + "</color>" + "키를 눌러주세요";
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
                    //장착할 무기 활성화
                    Tools[1]?.SetActive(false);
                    //Tools[2]?.SetActive(false);
                    Tools[equipItem].SetActive(true);
                    EquipTool = Tools[equipItem].GetComponent<EquipItem>();
                    //장착 애니메이션 활성화
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
                    //장착할 무기 활성화
                    Tools[equipItem].SetActive(true);
                    Tools[0]?.SetActive(false);
                    //Tools[2]?.SetActive(false);
                    EquipTool = Tools[equipItem].GetComponent<EquipItem>();
                    //장착 애니메이션 활성화
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

