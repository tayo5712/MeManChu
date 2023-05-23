using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownStair : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.StartMissionOther("Mission3", "지하실로 향하여라.");
            Destroy(this);
        }
    }
}
