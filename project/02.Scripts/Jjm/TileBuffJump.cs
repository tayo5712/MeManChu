using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuffJump : MonoBehaviour
{
    GameObject player;
    public GameObject buffFind;
    ThirdPersonController JumpBuff;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            JumpBuff = other.GetComponent<ThirdPersonController>();
            buffFind.GetComponent<BuffControlJump>().JumpHigh(JumpBuff);
        }
    }
}
