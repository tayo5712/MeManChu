using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuff : MonoBehaviour
{
    GameObject player;
    public GameObject buffFind;
    ThirdPersonController MoveSpeedBuff;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MoveSpeedBuff = other.GetComponent<ThirdPersonController>();
            buffFind.GetComponent<BuffControl>().SpeedChange(MoveSpeedBuff);

        }
    }
}
