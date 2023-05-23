using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        /*PhotonNetwork.AutomaticallySyncScene = true;*/
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    private void Start()
    {
        PhotonNetwork.JoinRoom("My Room");    // �κ��!
    }
    /*public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.Inlobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRoom("My Room");    // �κ��!
    }*/

    // ������ �� ������ �������� ��� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        // ���� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;  // �ִ� ������ �� : 20��
        ro.IsOpen = true; // ���� ���� ����
        ro.IsVisible = true; // �κ񿡼� �� ��Ͽ� ���� ��ų�� ����

        // �� ����
        PhotonNetwork.CreateRoom("My Room", ro);
    }

    // �� ������ �Ϸ�� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    // �� ������ �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNertwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        // �뿡 ������ ����� ����
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
            // $ => String.Format()
        }
        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);
        PhotonNetwork.Instantiate("Run_Player1", points[idx].position, points[idx].rotation, 0);
    }
}