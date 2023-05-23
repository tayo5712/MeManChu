using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayRun : MonoBehaviourPunCallbacks
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

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ����");
        Debug.Log($"PhotonNetwork.Inlobby = {PhotonNetwork.InLobby}");

        PhotonNetwork.JoinRoom("Main");    // ���� ��ġ����ŷ ��� ����
    }


    // ������ �� ������ �������� ��� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        // ���� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;  // �ִ� ������ �� : 20��
        // ro.IsOpen = true; // ���� ���� ����
        ro.IsVisible = true; // �κ񿡼� �� ��Ͽ� ���� ��ų�� ����

        // �� ����
        PhotonNetwork.CreateRoom("Main", ro);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Crea2132ted Room");
        Debug.Log($"Room2332 Name = {PhotonNetwork.CurrentRoom.Name}");
        PhotonNetwork.JoinRoom("Main");
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

        // ĳ���� ���� ������ �迭�� ����
        /*   Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
           int idx = Random.Range(1, points.Length);
           // ĳ���͸� ����
           PhotonNetwork.Instantiate("RunUser", points[idx].position, points[idx].rotation, 0);*/
        StartCoroutine(newcha());
    }

    IEnumerator newcha()
    {
        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);
        yield return new WaitForSeconds(6f);
        PhotonNetwork.Instantiate("Run_Player1", points[idx].position, points[idx].rotation, 0);
    }
}


