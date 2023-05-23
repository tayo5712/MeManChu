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
        Debug.Log("로비 연결");
        Debug.Log($"PhotonNetwork.Inlobby = {PhotonNetwork.InLobby}");

        PhotonNetwork.JoinRoom("Main");    // 랜덤 매치메이킹 기능 제공
    }


    // 랜덤함 룸 입장이 실패했을 경우 호출되는 콜백 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        // 룸의 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;  // 최대 접속자 수 : 20명
        // ro.IsOpen = true; // 룸의 오픈 여부
        ro.IsVisible = true; // 로비에서 룸 목록에 노출 시킬지 여부

        // 룸 생성
        PhotonNetwork.CreateRoom("Main", ro);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Crea2132ted Room");
        Debug.Log($"Room2332 Name = {PhotonNetwork.CurrentRoom.Name}");
        PhotonNetwork.JoinRoom("Main");
    }

    // 움에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNertwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        // 룸에 접속한 사용자 정보
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
            // $ => String.Format()
        }

        // 캐릭터 출현 정보를 배열에 저장
        /*   Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
           int idx = Random.Range(1, points.Length);
           // 캐릭터를 생성
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


