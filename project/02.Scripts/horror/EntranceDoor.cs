using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    AudioSource audioSource;
    BoxCollider boxCollider;
    public GameObject portal;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            if (!player.hasEntranceKey)
            {
                player.accessText.text = "현관 열쇠가 없습니다.";
                player.accessText.color = Color.red;
                player.accessText.gameObject.SetActive(true);
            }

            else
            {
                player.accessText.text = "'E'키를 눌러서 탈출하세요";
                player.accessText.gameObject.SetActive(true);
                if (player.eDown)
                {
                    audioSource.Play();
                    StartCoroutine(OpenDoor1());
                    StartCoroutine(OpenDoor2());
                    Destroy(boxCollider);
                    player.accessText.gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator OpenDoor1()
    {
        GameObject Entrance1 = transform.Find("Entrance1").gameObject;

        for (int i = 0; i < 110; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Entrance1.transform.Rotate(0, -1, 0);
        }
    }
    IEnumerator OpenDoor2()
    {
        GameObject Entrance2 = transform.Find("Entrance2").gameObject;

        for (int i = 0; i < 110; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Entrance2.transform.Rotate(0, 1, 0);
        }
        portal.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.color = Color.white;
            player.accessText.gameObject.SetActive(false);
        }
    }
}
