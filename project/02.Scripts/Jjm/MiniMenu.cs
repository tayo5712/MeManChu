using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class MiniMenu : MonoBehaviour
{
    public void OnClickLobby()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Loading2");
    }
}
