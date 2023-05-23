using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
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
            player.accessText.text = "'E'Ű�� ������ ���ڸ� �������";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                StartCoroutine(OpenBox(player));
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

    public IEnumerator OpenBox(horrorPlayer player)
    {
        audioSource.Play();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.0025f);
            transform.Rotate(-1, 0, 0);
        }
        player.ObtainMessageOther("�ƹ��͵� ���� �� ����...");
        Destroy(this);
    }
}
