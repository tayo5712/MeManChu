using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            audioSource.Play();
        }
    }

}
