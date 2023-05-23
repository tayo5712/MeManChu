using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HorrorManager : MonoBehaviour
{
    public float playTime;
    public GameObject TutorialPanel;
    public RectTransform TutorialGroup1;
    public RectTransform TutorialGroup2;
    public RectTransform TutorialGroup3;
    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public GameObject GameFinishPanel;
    public GameObject DamagePanel;
    public Image[] hearts;
    public TMP_Text playTimeTxt;
    public TMP_Text finishTimeTxt;
    public GameObject[] DeadMans;
    public horrorPlayer HorrorPlayer;
    public bool isStart;

    void Awake()
    {

    }
    void Start()
    {
        TutorialGroup1.anchoredPosition = Vector3.zero;
    }
    public void Update()
    {
        if (isStart)
        {
            playTime += Time.deltaTime;
        }
    }

    public void LateUpdate()
    {
        int min = (int)(playTime / 60);
        int second = (int)(playTime % 60);
        playTimeTxt.text =  string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PhotonNetwork.LeaveRoom();


    }
    public void GoMain()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Loading2");
    }
    public void GameOver()
    {
        foreach (GameObject obj in DeadMans)
        {
            obj.GetComponent<AudioSource>().Stop();
        }
        // 게임오버 시, 게임 판넬은 비활성화하고 게임오버 판넬 활성화
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        StartCoroutine(FadeIn(GameOverPanel));
    }

    public void GameFinish()
    {
        foreach (GameObject obj in DeadMans)
        {

            obj.SetActive(false);
        }

        GamePanel.SetActive(false);
        GameFinishPanel.SetActive(true);
        StartCoroutine(FadeIn(GameFinishPanel));
        int min = (int)(playTime / 60);
        int second = (int)(playTime % 60);
        finishTimeTxt.text = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);

        string id = PlayerPrefs.GetString("ID").ToString();
        string name = PlayerPrefs.GetString("NAME").ToString();
        string map = "HorrorHouse"; // 맵 이름
        string time = "00:"+finishTimeTxt.text;
        StartCoroutine(REST.postRankIns(new RANK(id, name, map, time)));
    }

    public void myHelath(int health)
    {
        StartCoroutine(Damaged());
        hearts[health].enabled = false;
    }
    IEnumerator FadeIn(GameObject obj)
    {
        for (int i = 0; i < 100; i++)
        {
            obj.GetComponent<CanvasGroup>().alpha += 0.01f; 
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Damaged()
    {
        DamagePanel.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            DamagePanel.GetComponent<CanvasGroup>().alpha += 0.005f;
            yield return new WaitForSeconds(0.005f);
        }
        for (int i = 0; i < 100; i++)
        {
            DamagePanel.GetComponent<CanvasGroup>().alpha -= 0.01f;
            yield return new WaitForSeconds(0.005f);
        }
        DamagePanel.SetActive(false);

    }

    public void Go2Page()
    {
        TutorialGroup1.anchoredPosition = Vector3.down * 1000;
        TutorialGroup2.anchoredPosition = Vector3.zero;
    }

    public void Go3Page()
    {
        TutorialGroup2.anchoredPosition = Vector3.down * 1000;
        TutorialGroup3.anchoredPosition = Vector3.zero;
    }

    public void GameStart()
    {
        isStart = true;
        TutorialPanel.SetActive(false);
        GamePanel.SetActive(true);
        HorrorPlayer.GameStart();
    }
}
