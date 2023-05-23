using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookHint : MonoBehaviour
{
    public RectTransform HintGroup;
    public TMP_Text HintContent;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "������ Ȯ���� ����";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                player.accessText.gameObject.SetActive(false);
                StartCoroutine(StartHint("�츮�� #### ����?..."));
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
        yield return new WaitForSeconds(3f);
        HintGroup.anchoredPosition = Vector3.down * 1000;
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
