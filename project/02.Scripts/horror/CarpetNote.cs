using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarpetNote : MonoBehaviour
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
                StartCoroutine(StartHint("죽은자들을 조심해,\n등 뒤는 안전할꺼야..."));
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
        HintGroup.anchoredPosition = Vector3.zero + Vector3.up * 50;
        yield return new WaitForSeconds(3f);
        HintGroup.anchoredPosition = Vector3.down * 1000;
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
