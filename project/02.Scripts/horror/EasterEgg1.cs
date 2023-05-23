using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EasterEgg1 : MonoBehaviour
{
    public RectTransform HintGroup;
    public TMP_Text HintContent;
    public TMP_Text alertText;
    private string[] EasterEgg;

    void Awake()
    {
        SettingEasterEgg();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "���� ������ �ִ�.";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                player.accessText.gameObject.SetActive(false);
                string egg = EasterEgg[Random.Range(0, 6)];
                StartCoroutine(StartHint(egg));
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.gameObject.SetActive(false);
        }
    }

    public IEnumerator StartHint(string content)
    {
        HintContent.text = content;
        HintGroup.anchoredPosition = Vector3.zero;
        alertText.text = "���� ���� ���� ���� �����ִ� �� ����.";
        alertText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        HintGroup.anchoredPosition = Vector3.down * 1000;
        alertText.gameObject.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    void SettingEasterEgg()
    {
        EasterEgg = new string[]
        {
            "���¿�¯¯��",
            "�����������±�",
            "���ǾƵ��¹�",
            "������������",
            "����̰�����",
            "����������"
        };
    }
}
