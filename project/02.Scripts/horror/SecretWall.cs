using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    AudioSource audioSource;
    public bool isPlay;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlay)
        {
            isPlay = true;
            audioSource.Play();
            StartCoroutine(whispering());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "뭔가 위화감이 드는 벽이다...";
            player.accessText.gameObject.SetActive(true);
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

    IEnumerator whispering()
    {
        yield return new WaitForSeconds(24f);
        isPlay = false;
    }
}
