using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_SsafyRun : MonoBehaviourPunCallbacks
{
  
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("���̵�");
        SceneManager.LoadScene("Loading_Run");
    }
}