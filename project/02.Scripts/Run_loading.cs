using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run_loading : MonoBehaviour
{
    public string scenename;
    void Start()
    {
        Invoke("Load",2f);
    }
    void Load()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        SceneManager.LoadScene(scenename);
    }
}