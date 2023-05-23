using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    BoxCollider boxCollider;
    public bool isDone;
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
            player.accessText.text = "한 번 건들여 볼까";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                Destroy(boxCollider);
                player.accessText.gameObject.SetActive(false);
                gameObject.AddComponent<Rigidbody>();
                isDone = true;
                audioSource.Play();
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
}
