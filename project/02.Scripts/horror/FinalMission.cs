using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMission : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.gameObject.GetComponent<horrorPlayer>();
            if (player.hasEntranceKey)
            {
                Destroy(this);
                player.StartMissionOther("Mission5", "�����ڵ��� ������\nŻ���ϼ���!!!");
            }
        }
    }
}
