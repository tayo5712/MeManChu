using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookHint2 : MonoBehaviour
{
    public RectTransform HintGroup;
    public TMP_Text HintContent;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "쪽지를 확인해 보자";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                player.accessText.gameObject.SetActive(false);
                StartCoroutine(StartHint("어딘가에 알 수 없는 \n숫자가 쓰여있어.."));
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
