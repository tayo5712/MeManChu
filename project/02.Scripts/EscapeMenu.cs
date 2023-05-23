using Photon.Pun;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    private Scene scene;


    public RunSave runSave;
    public GameObject player;

    private GameObject borken;

    // 게임종료
    public void GameQuit()
    {
        Application.Quit();
    }

    // 로비로
    public void ToLobby()
    {
        borken = GameObject.FindGameObjectWithTag("Keep");
        if (borken != null )
        {
            Destroy(borken);
        }
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Loading2");
    }

    // 재시작 or 세이브 포인트로
    public void Restart()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "SsafyRun")
        {
            if (runSave.savepoint[3] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -3f;
                originPoint.y = 119f;
                originPoint.z = -139f;
                player.transform.position = originPoint;
            }
            else if (runSave.savepoint[2] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -227f;
                originPoint.y = 43f;
                originPoint.z = -33f;
                player.transform.position = originPoint;
            }
            else if (runSave.savepoint[1] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -225f;
                originPoint.y = 38f;
                originPoint.z = 230f;
                player.transform.position = originPoint;
            }
            else if (runSave.savepoint[0] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -20f;
                originPoint.y = 9f;
                originPoint.z = 235f;
                player.transform.position = originPoint;
            }
            else
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = 0f;
                originPoint.y = 0.5f;
                originPoint.z = 0f;
                player.transform.position = originPoint;
            }
        }
        else if (scene.name == "Floor3" || scene.name == "Fire_2" || scene.name == "Fire_1")
        {
            player.GetComponent<ThirdPersonController>().Die();
        }
        else
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(scene.name);
        }
    }


}
