using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoor : MonoBehaviour
{
    BoxCollider boxCollider;
    AudioSource audioSource;

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
            player.accessText.text = "'E'키를 눌러서 안을 확인해보세요";
            player.accessText.gameObject.SetActive(true);
            if (player.eDown)
            {
                audioSource.Play();
                StartCoroutine(OpenDoor1(player));
                StartCoroutine(OpenDoor2());
                Destroy(boxCollider);
                player.accessText.gameObject.SetActive(false);
            }

        }
    }

    IEnumerator OpenDoor1(horrorPlayer player)
    {
        GameObject LeftDoor = transform.Find("LeftDoor").gameObject;

        for (int i = 0; i < 110; i++)
        {
            yield return new WaitForSeconds(0.01f);
            LeftDoor.transform.Rotate(0, 1, 0);
        }
        player.ObtainMessageOther("접시밖에 없는 것 같다...");
    }
    IEnumerator OpenDoor2()
    {
        GameObject RightDoor = transform.Find("RightDoor").gameObject;

        for (int i = 0; i < 110; i++)
        {
            yield return new WaitForSeconds(0.01f);
            RightDoor.transform.Rotate(0, -1, 0);
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
}
