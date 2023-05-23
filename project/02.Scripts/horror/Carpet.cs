using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    public GameObject CarpetNote;
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
            player.accessText.text = "������ ī���̴�... ġ������?";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                StartCoroutine(Drag());
                Destroy(boxCollider);
                player.accessText.gameObject.SetActive(false);
                player.ObtainMessageOther("������ ������ �������ִ�.");
                CarpetNote.GetComponent<BoxCollider>().enabled = true;
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

    public IEnumerator Drag()
    {
        audioSource.Play();
        for (int i = 0; i < 80; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Translate(0, 0, -0.01f);
        }
        Destroy(this);
    }
}
