using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarretBox : MonoBehaviour
{
    public GameObject GarretKey;
    public GameObject BoxCover;
    public BoxCollider boxCollider;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "'E'키를 눌러서 상자를 열어보세요";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                StartCoroutine(OpenBox());
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

    public IEnumerator OpenBox()
    {
        audioSource.Play();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            BoxCover.transform.Rotate(-1, 0 ,0);
        }
        GarretKey.GetComponent<BoxCollider>().enabled = true;
        Destroy(this);
    }
}
