using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class photonManager : MonoBehaviourPunCallbacks
{
    // 버전 입력
    private readonly string version = "1.0";
    // 사용자 아이디 입력
    private string userId;
    // 사용자가 선택한 캐릭터
    private int CHIDX;
    // 소환할 캐릭터 이름

    private Scene scene;

    // Start is called before the first frame update
    private void Awake()
    {
        //유저아이디 가져오기
        userId = PlayerPrefs.GetString("NAME").ToString();
        //유저가 선택한 캐릭터 인덱스
        CHIDX = PlayerPrefs.GetInt("CHIDX");
        //씬이름 가져오기
        scene = SceneManager.GetActiveScene();
        // 같은 룸의 유저들에게 자동으로 씬을 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
        // 같은 버전의 유저끼리 접속 허용
        PhotonNetwork.GameVersion = version;
        // 유저 아이디 할당
        PhotonNetwork.NickName= userId;
        // 포톤 서버와 통신 횟수 설정. 초당 30회
        Debug.Log(PhotonNetwork.SendRate);
        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();
        
    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.Inlobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby(); // 로비 입장
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.Inlobby = {PhotonNetwork.InLobby}");
        if (scene.name == "MainScene")
        {
            PhotonNetwork.JoinRoom("Lobby");
        }
        else if (scene.name == "SsafyRun")
        {
            PhotonNetwork.JoinRoom("Run");
        }
        else if (scene.name == "MiniGame")
        {
            PhotonNetwork.JoinRoom("Mini");
        }
        else
        {
            //PhotonNetwork.JoinRoom("HOOOOR");
            PhotonNetwork.JoinRoom(userId);
        }
    }

    // 랜덤함 룸 입장이 실패했을 경우 호출되는 콜백 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        // 룸의 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;  // 최대 접속자 수 : 20명
        ro.IsOpen= true; // 룸의 오픈 여부
        ro.IsVisible = true; // 로비에서 룸 목록에 노출 시킬지 여부

        // 룸 생성
        if (scene.name == "MainScene")
        {
            PhotonNetwork.CreateRoom("Lobby", ro);
        }
        else if (scene.name == "SsafyRun")
        {
            PhotonNetwork.CreateRoom("Run", ro);
        }
        else if (scene.name == "MiniGame")
        {
            PhotonNetwork.CreateRoom("Mini", ro);
        }
        else
        {
            PhotonNetwork.CreateRoom(userId, ro);
        }

    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    // 움에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNertwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        // 룸에 접속한 사용자 정보
        foreach(var player in PhotonNetwork.CurrentRoom.Players)
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
        Scene scene = SceneManager.GetActiveScene();
        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);
        yield return new WaitForSeconds(0f);
        if (scene.name == "Giantroom")
        {
            PhotonNetwork.Instantiate("GiantRoom/G_player1 " + (CHIDX + 1) , points[idx].position, points[idx].rotation, 0);
        }
        else if (scene.name == "HorrorHouse")
        {
            PhotonNetwork.Instantiate("HorrorRoom/HorrorUser " + (CHIDX + 1) , points[idx].position, points[idx].rotation, 0);
        }
        else if (scene.name == "MiniGame")
        {
            PhotonNetwork.Instantiate("MiniGame/Fall_Player1 " + (CHIDX + 1), points[idx].position, points[idx].rotation, 0);
        }
        else if (scene.name == "Floor3")
        {
            PhotonNetwork.Instantiate("FireTheme/user1 " + (CHIDX + 1), points[idx].position, points[idx].rotation, 0);
        }
        else if (scene.name == "SsafyRun")
        {
            Debug.Log("런맵 로딩됫음????");
            yield return new WaitForSeconds(7f);
            PhotonNetwork.Instantiate("SSafyRun/" + "user1 " + (CHIDX + 1), points[idx].position, points[idx].rotation, 0);
        }
        else
        {   
            PhotonNetwork.Instantiate("SSafyRun/" + "user1 " + (CHIDX+1), points[idx].position, points[idx].rotation, 0);
        }
    }
}
