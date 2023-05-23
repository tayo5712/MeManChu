using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_horror : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Loading_Horror");
    }
}
