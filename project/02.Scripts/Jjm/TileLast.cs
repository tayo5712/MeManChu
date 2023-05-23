using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLast : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("LastTile", 3f);
        }
    }

    void LastTile()
    {
        gameObject.SetActive(false);
    }
}
