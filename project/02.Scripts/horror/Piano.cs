using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    BoxCollider boxCollider;
    AudioSource audioSource;
    public bool isPlay;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlay)
        {
            StartCoroutine(PlayingPiano());
        }
    }

    IEnumerator PlayingPiano()
    {
        isPlay = true;
        audioSource.Play();
        yield return new WaitForSeconds(5f);
        isPlay = false;
    }
}
