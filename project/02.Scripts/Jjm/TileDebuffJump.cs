using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDebuffJump : MonoBehaviour
{
    GameObject player;
    public GameObject DebuffJumpFind;
    ThirdPersonController JumpDebuff;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            JumpDebuff = other.GetComponent<ThirdPersonController>();
            DebuffJumpFind.GetComponent<DebuffControlJump>().JumpDown(JumpDebuff);
        }
    }
}
