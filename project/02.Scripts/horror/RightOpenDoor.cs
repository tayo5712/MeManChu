using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightOpenDoor : MonoBehaviour
{
    BoxCollider boxCollider;
    public TMP_Text alertText;
    AudioSource audioSource;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "'E'키를 눌러서 문을 열어보세요";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                StartCoroutine(OpenDoor());
                StartCoroutine(Message("당근 한 개가 있다."));
                Destroy(boxCollider);
                player.accessText.gameObject.SetActive(false);
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

    public IEnumerator OpenDoor()
    {
        audioSource.Play();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Rotate(0, -1, 0);
        }
    }

    IEnumerator Message(string message)
    {
        yield return new WaitForSeconds(0.5f);
        alertText.text = message;
        alertText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        alertText.gameObject.SetActive(false);
    }
}

