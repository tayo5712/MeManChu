using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// UI : UI 기능 사용을 위한 것
using UnityEngine.SceneManagement;
// SceneManagement : 씬 전환을 위한 것

public class TurnOnTheStage : MonoBehaviour {
   
    bool bTurnLeft = false;
    bool bTurnRight = false;
    private Quaternion turn = Quaternion.identity;
    // 정의
    public static int charactorNum = 0;
    float value = 0;
    float turnDegree = 14.4f;
	// Use this for initialization
	void Start () {
        turn.eulerAngles = new Vector3(0, value, 0);
        // 각을 초기화합니다.
	}
	
	// Update is called once per frame
	void Update () {
		if(bTurnLeft)
        {
            Debug.Log("Left");
            charactorNum++;
            if (charactorNum == 25)
                charactorNum = 0;
            value -= turnDegree;
            // 각도를 90도 뺍니다.
            bTurnLeft = false;
            // 부울 변수를 취소합니다.
        }
        if(bTurnRight)
        {
            Debug.Log("Right");
            charactorNum--;
            if (charactorNum == -1)
                charactorNum = 24;
            value +=  turnDegree;
            // 각도를 90도 더합니다.
            bTurnRight = false;
            // 부울 변수를 취소합니다.
        }
        turn.eulerAngles = new Vector3(0, value, 0);
        // 각도를 잽니다.
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * 5.0f);
        // 돌립니다.
	}

    public void turnLeft()
    {
        bTurnLeft = true;
        bTurnRight = false;
        // 다른 버튼을 누를때의 컨트롤
    }

    public void turnRight()
    {
        bTurnRight = true;
        bTurnLeft = false;
        // 다른 버튼을 누를때의 컨트롤
    }

    public void turnStage()
    {
        PlayerPrefs.SetInt("CHIDX", charactorNum);
        //PlayerPrefs.GetInt("CHIDX");
        // 스테이지 전환을 위한 함수
        SceneManager.LoadScene("Loading2");
    }
}
