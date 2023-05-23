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

    // 방 리스트 목록을 가져옴
    void Start()
    {
        roomList = GetComponent<RoomList>();
    }

    // 아무나 로비에 접속하면 방 정보 갱신
    public override void OnJoinedLobby()
    {
        if (roomList != null)
        {
            Debug.Log("갱신1");
            roomList.UpdateRoomList();
        }
    }

    // 방 생성
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(input_Create.text);
    }

    // 방 접속
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
    }

    // 작성한 이름에 맞는 방 접속
    public void JoinRoomInList(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    // 방 접속 시 해당 방의 씬으로 이동
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("PlayingScene");
    }

    // 닉네임 설정 (무조건 해줘야함, 조건 넣어야하는데 아직 안넣음)
    public void SetNickname()
    {
        PhotonNetwork.NickName = input_Nick.text;
    }*/
}