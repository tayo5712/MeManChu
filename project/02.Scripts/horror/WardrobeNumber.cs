using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeNumber : MonoBehaviour
{
    // Start is called before the first frame update
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
        for (int i = 0; i < 120; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Rotate(0, 1, 0);
        }
        player.ObtainMessageOther("아무것도 없는 것 같다...");
    }
}

