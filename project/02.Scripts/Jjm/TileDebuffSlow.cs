using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDebuffSlow : MonoBehaviour
{
    GameObject player;
    public GameObject DebuffFind;
    ThirdPersonController SlowDebuff;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SlowDebuff = other.GetComponent<ThirdPersonController>();
            DebuffFind.GetComponent<DebuffControlSlow>().SpeedSlow(SlowDebuff);
        }
    }
}
