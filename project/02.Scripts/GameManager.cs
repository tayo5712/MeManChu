using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isConnet = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(CreatePlayer());
    }
    void Update()
    {
        
    }

    IEnumerator CreatePlayer()
    {
        yield return new WaitUntil(() => isConnet);
        GameObject playerTemp = PhotonNetwork.Instantiate("Run_Player1", Vector3.one, Quaternion.identity, 0);
    }

    /*
        public ThirdPersonController thirdPersonController;
        public ItemInputSystem itemInputSystem;
        public int currentHealth;

        public TMP_Text HPText;
        public TMP_Text timerText;

        public int timer = 0;



        public Image weapon1Img;
        public Image weapon2Img;
        public Image weapon3Img;
        public Image weapon4Img;
        public Image weapon5Img;

        // 현재 씬 이름 확인
        private Scene scene;
        private string sceneName;


        // Start is called before the first frame update
        void Start()
        {
            // 현재 씬이름 불러오기
            scene = SceneManager.GetActiveScene();
            sceneName = scene.name;

            if (sceneName == "Floor3" || sceneName == "Fire_1" || sceneName == "Fire_2")
            {
                StartCoroutine(TimerCoroution());
            }
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (sceneName == "Floor3" || sceneName == "Fire_1" || sceneName == "Fire_2")
            {
                HPText.text = "" + thirdPersonController.currentHealth;

                weapon1Img.color = new Color(1,1,1, itemInputSystem.hasTools[0] ? 1: 0);
                weapon2Img.color = new Color(1, 1, 1, itemInputSystem.hasTools[1] ? 1 : 0);
                weapon3Img.color = new Color(1, 1, 1, itemInputSystem.hasTools[2] ? 1 : 0);
                weapon4Img.color = new Color(1, 1, 1, itemInputSystem.hasTools[3] ? 1 : 0);
                weapon5Img.color = new Color(1, 1, 1, itemInputSystem.hasTools[4] ? 1 : 0);
            }

        }

        IEnumerator TimerCoroution()
        {
            timer += 1;
            timerText.text = (timer / 60).ToString("D2") + ":" + (timer % 60).ToString("D2");

            yield return new WaitForSeconds(1f);

            StartCoroutine(TimerCoroution());
        }*/
}
