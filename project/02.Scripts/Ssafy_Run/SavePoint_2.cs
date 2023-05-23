using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint_2 : MonoBehaviour
{
    public AudioClip save;

    AudioSource audioSource;

    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        /* GameObject.FindGameObjectWithTag("Player").GetComponent<RunSave>().savepoint;*/
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
            other.gameObject.GetComponent<RunSave>().savepoint[1] = true;
            audioSource.clip = save;
            audioSource.Play();
        
    }
}
