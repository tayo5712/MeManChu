using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellarSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text accessText;
    public TMP_Text alertText;
    horrorPlayer player;
    BoxCollider boxCollider;
    public GameObject SecretWall1;
    public GameObject SecretWall2;
    AudioSource audioSource;

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
            player.accessText.text = "�̰� ���� ��ġ��?";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                player.accessText.gameObject.SetActive(false);
                Destroy(boxCollider);
                StartCoroutine(StartHint());
                StartCoroutine(TurnCellarSwitch());
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

    IEnumerator StartHint()
    {
        alertText.gameObject.SetActive(true);
        player.alertText.text = "���� ��򰡿��� ���� �����̴� �Ҹ��� �鸰��.";
        yield return new WaitForSeconds(2f);
        player.alertText.text = "�����? 1��? 2��?...";
        yield return new WaitForSeconds(2f);
        alertText.gameObject.SetActive(false);
    }

    IEnumerator TurnCellarSwitch()
    {
        audioSource.Play();
        for (int i = 0; i < 70; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Rotate(1, 0, 0);
        }
        SecretWall1.SetActive(false);
        SecretWall2.SetActive(true);
    }
}
