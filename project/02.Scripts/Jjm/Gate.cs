using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Loading_Sky");
    }
}
