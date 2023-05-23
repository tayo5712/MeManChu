using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
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
            player.accessText.text = "'E'키를 눌러서 서랍을 확인해보세요.";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                StartCoroutine(OpenDoor(player));
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

    public IEnumerator OpenDoor(horrorPlayer player)
    {
        audioSource.Play();
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Translate(0, 0, 0.01f);

        }
        player.ObtainMessageOther("아무것도 없는것 같다..");
    }
}
