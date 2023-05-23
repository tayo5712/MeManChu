using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellarDoor : MonoBehaviour
{
    BoxCollider boxCollider;
    public GameObject CellarGate;
    horrorPlayer player;
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
            player = other.GetComponent<horrorPlayer>();
            if (player.hasCellarKey)
            {
                player.accessText.text = "'E'키를 눌러서 지하실 문을 여세요.";
                player.accessText.gameObject.SetActive(true);
                
                if (player.eDown)
                {
                    StartCoroutine(OpenDoor());
                    Destroy(boxCollider);
                    player.accessText.gameObject.SetActive(false);
                }
            }
            else
            {
                player.accessText.text = "지하실 열쇠가 없습니다.";
                player.accessText.color = Color.red;
                player.accessText.gameObject.SetActive(true);
            }
        }
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

    public IEnumerator OpenDoor()
    {
        audioSource.Play();
        CellarGate.GetComponent<BoxCollider>().isTrigger = true;
        for (int i = 0; i < 110; i++)
        {
            yield return new WaitForSeconds(0.005f);
            CellarGate.transform.Rotate(0, 1, 0);
        }
        player.StartMissionOther("Mission4", "현관 열쇠는 어디에?");
        Destroy(this);
    }
}
