using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    // ���� �Է�
    private readonly string version = "1.0";
    // ����� ���̵� �Է�
    
    void Awake()
    {   
        /*PhotonNetwork.AutomaticallySyncScene = true;*/
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ����");
    }
}
