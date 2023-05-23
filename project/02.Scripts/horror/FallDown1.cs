using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown1 : MonoBehaviour
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
                StartCoroutine(StartHint(player));
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

    IEnumerator StartHint(horrorPlayer player)
    {
        yield return new WaitForSeconds(1f);
        player.ObtainMessageOther("알 수 없는 숫자가 써져 있다.");
    }
}
