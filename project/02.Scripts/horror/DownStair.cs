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
            player.StartMissionOther("Mission3", "���ϽǷ� ���Ͽ���.");
            Destroy(this);
        }
    }
}
