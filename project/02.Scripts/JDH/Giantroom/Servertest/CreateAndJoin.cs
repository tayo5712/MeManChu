// CreateAndJoin.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    /*public TMP_InputField input_Create;
    public TMP_InputField input_Join;
    public TMP_InputField input_Nick;
    private RoomList roomList;

    // �� ����Ʈ ����� ������
    void Start()
    {
        roomList = GetComponent<RoomList>();
    }

    // �ƹ��� �κ� �����ϸ� �� ���� ����
    public override void OnJoinedLobby()
    {
        if (roomList != null)
        {
            Debug.Log("����1");
            roomList.UpdateRoomList();
        }
    }

    // �� ����
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(input_Create.text);
    }

    // �� ����
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
    }

    // �ۼ��� �̸��� �´� �� ����
    public void JoinRoomInList(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    // �� ���� �� �ش� ���� ������ �̵�
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("PlayingScene");
    }

    // �г��� ���� (������ �������, ���� �־���ϴµ� ���� �ȳ���)
    public void SetNickname()
    {
        PhotonNetwork.NickName = input_Nick.text;
    }*/
}