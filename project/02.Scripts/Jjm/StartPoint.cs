using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    GameObject player;
    ThirdPersonController GravityLow;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GravityLow = other.GetComponent<ThirdPersonController>();
            StartCoroutine(GravityDown());
        }
    }

    IEnumerator GravityDown()
    {
        Debug.Log("gravity");
        GravityLow.Gravity = 5f;
        yield return new WaitForSeconds(3f);
        GravityLow.Gravity = -15f;
    }
}
