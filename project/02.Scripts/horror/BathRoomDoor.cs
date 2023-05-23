using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoomDoor : MonoBehaviour
{
    public GameObject BathDoor;
    BoxCollider boxCollider;
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
        BathDoor.GetComponent<BoxCollider>().isTrigger = true;
        audioSource.Play();
        for (int i = 0; i < 110; i++)
        {
            yield return new WaitForSeconds(0.005f);
            BathDoor.transform.Rotate(0, -1, 0);
        }
    }
}
