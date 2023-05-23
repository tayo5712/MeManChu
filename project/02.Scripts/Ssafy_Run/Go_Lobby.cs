using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Go_Lobby : MonoBehaviourPunCallbacks
{
    public Button Lobby;
    void Start()
    {
        /*Lobby.onClick.AddListener(GoLobby);*/
    }
    public void GoLobby()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Loading2");
    }
    
}