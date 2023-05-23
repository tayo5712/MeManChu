using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapForUser : MonoBehaviour
{

    public GameObject MapUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MapUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MapUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            MapUI.SetActive(false);
        }
    }

}
