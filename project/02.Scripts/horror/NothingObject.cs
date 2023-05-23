using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingObject : MonoBehaviour
{

    public string message;
    horrorPlayer player;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<horrorPlayer>();
            player.alertText.text = message;
            player.alertText.gameObject.SetActive(true);
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.alertText.gameObject.SetActive(false);
        }    
    }
}
