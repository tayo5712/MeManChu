using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prison : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Doorclip;
    public GameObject Lock;
    public GameObject LockStick;
    public GameObject Stick;
    public GameObject Door;
    public TMP_Text accessText;
    public TMP_Text alertText;
    BoxCollider boxCollider;
    horrorPlayer player;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<horrorPlayer>();
            if (player.hasPrisonKey)
            {
                player.accessText.text = "'E'키를 눌러서 감옥 문을 여세요.";
                player.accessText.gameObject.SetActive(true);
                if (player.eDown)
                {
                    boxCollider.enabled = false;
                    StartCoroutine(Unlock());
                }
            }
            else
            {
                player.accessText.color = Color.red;
                player.accessText.text = "감옥 열쇠가 없습니다.";
                player.accessText.gameObject.SetActive(true);
            }
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.gameObject.SetActive(false);
            player.accessText.color = Color.white;
        }
    }

    IEnumerator Unlock()
    {
        audioSource.Play();
        for (int i = 0; i < 90; i++)
        {
            LockStick.transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }

        Lock.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 9; i++)
        {
            Stick.transform.Translate(0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        audioSource.clip = Doorclip;
        audioSource.Play();
        Door.GetComponent<BoxCollider>().isTrigger = true;
        for (int i = 0; i < 160; i++)
        {
            Door.transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }

    }
}
