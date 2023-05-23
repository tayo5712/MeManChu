using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crow : MonoBehaviour
{
    public bool isPlay;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlay)
        {
            audioSource.Play();
        }    
    }
}
