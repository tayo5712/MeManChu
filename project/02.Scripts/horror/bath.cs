using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bath : MonoBehaviour
{
    AudioSource audioSource;
    BoxCollider boxCollider;
    public GameObject PrisonKey;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "배수구가 막혀있다. 'E'키로 뚫어보자";
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
        audioSource.Play();
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.05f);
            transform.localScale *= 0.95f;
        }
        PrisonKey.GetComponent<BoxCollider>().enabled = true;
        Destroy(this);
    }
}
