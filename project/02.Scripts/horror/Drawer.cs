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
            player.accessText.text = "'E'Ű�� ������ ������ Ȯ���غ�����.";
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
        player.ObtainMessageOther("�ƹ��͵� ���°� ����..");
    }
}
