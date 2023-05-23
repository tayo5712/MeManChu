using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class photonManager : MonoBehaviourPunCallbacks
{
    // ���� �Է�
    private readonly string version = "1.0";
    // ����� ���̵� �Է�
    private string userId;
    // ����ڰ� ������ ĳ����
    private int CHIDX;
    // ��ȯ�� ĳ���� �̸�

    private Scene scene;

    // Start is called before the first frame update
    private void Awake()
    {
        //�������̵� ��������
        userId = PlayerPrefs.GetString("NAME").ToString();
        //������ ������ ĳ���� �ε���
        CHIDX = PlayerPrefs.GetInt("CHIDX");
        //���̸� ��������
        scene = SceneManager.GetActiveScene();
        // ���� ���� �����鿡�� �ڵ����� ���� �ε�
        PhotonNetwork.AutomaticallySyncScene = true;
        // ���� ������ �������� ���� ���
        PhotonNetwork.GameVersion = version;
        // ���� ���̵� �Ҵ�
        PhotonNetwork.NickName= userId;
        // ���� ������ ��� Ƚ�� ����. �ʴ� 30ȸ
        Debug.Log(PhotonNetwork.SendRate);
        // ���� ����
        PhotonNetwork.ConnectUsingSettings();
        
    }

    // ���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.Inlobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby(); // �κ� ����
    }

    // �κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
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

    // ������ �� ������ �������� ��� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        // ���� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;  // �ִ� ������ �� : 20��
        ro.IsOpen= true; // ���� ���� ����
        ro.IsVisible = true; // �κ񿡼� �� ��Ͽ� ���� ��ų�� ����

        // �� ����
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
        foreach(var player in PhotonNetwork.CurrentRoom.Players)
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
            Debug.Log("���� �ε�����????");
            yield return new WaitForSeconds(7f);
            PhotonNetwork.Instantiate("SSafyRun/" + "user1 " + (CHIDX + 1), points[idx].position, points[idx].rotation, 0);
        }
        else
        {   
            PhotonNetwork.Instantiate("SSafyRun/" + "user1 " + (CHIDX+1), points[idx].position, points[idx].rotation, 0);
        }
    }
}
