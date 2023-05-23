using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    float rightMax = 2.0f; //좌로 이동가능한 (x)최대값

    float leftMax = -2.0f; //우로 이동가능한 (x)최대값

    float currentPosition; //현재 위치(x) 저장

    float movePosition; //현재 위치(x) 저장

    float leftm;
    float rightm;

    private Transform currentTransform;

    float direction = 3.0f; //이동속도+방향



    void Start()

    {
        currentPosition = GetComponent<Transform>().position.x;
        Debug.Log(currentPosition);
        //        currentPosition = gameObject.transform.position.x;
        leftm = currentPosition + leftMax;
        rightm = currentPosition + rightMax;

    }


    void Update()

    {

        currentPosition += Time.deltaTime * direction;
        Debug.Log(leftm);
        Debug.Log(rightm);
        Debug.Log(currentPosition);
        if (currentPosition >=  rightm)
        {
            Debug.Log("우로이동");
            direction *= -1;

            currentPosition = rightm;

        }

        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정

        else if (currentPosition <= leftm)

        {
            Debug.Log("좌로이동");
            direction *= -1;

            currentPosition = leftm;

        }

        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정

        transform.position = new Vector3(currentPosition, 0, 0);

        //"Stone"의 위치를 계산된 현재위치로 처리
    }
}