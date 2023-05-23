// ConnectToServer.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public int trig = 0;

    
    void Start()    
    {
        Invoke("goCharacter", 5f);
    }

    void goCharacter()
    {
        SceneManager.LoadScene("CharaterSelect");
    }

}


/*using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string version = "1.0";
    private string userID = "moon2"; // 사용자 닉네임과 이어야함

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userID;

        Debug.Log($"{userID} : {PhotonNetwork.SendRate}");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"{userID} : Connected to Master!");
        Debug.Log($"{userID} : PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log($"{userID} : PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string msg)
    {
        Debug.Log($"{userID} : JoinRandom Filed {returnCode} : {msg}");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;
        ro.IsVisible = true;

        PhotonNetwork.CreateRoom("My Room", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"{userID} : Created Room!");
        Debug.Log($"{userID} : Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"{userID} : PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"{userID} : Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{userID} : {player.Value.NickName}, {player.Value.ActorNumber}");
        }

        Transform[] points = GameObject.Find("spawnPoints").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        Debug.Log(points[idx]);
        PhotonNetwork.Instantiate("user1", points[idx].position, points[idx].rotation, 0);
    }
}
*/