// GameStart.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Golobby : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Loading2");
    }
    
}