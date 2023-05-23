// ConnectToServer.cs
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ConnectToServer2 : MonoBehaviour
{
    /*
     void Start()    
     {
         PhotonNetwork.AutomaticallySyncScene = true;
         PhotonNetwork.ConnectUsingSettings();
     }*/


    // PhotonNetwork.JoinLobby();
    void Start() {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        SceneManager.LoadScene("MainScene");
    }
}