using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    float rightMax = 2.0f; //�·� �̵������� (x)�ִ밪

    float leftMax = -2.0f; //��� �̵������� (x)�ִ밪

    float currentPosition; //���� ��ġ(x) ����

    float movePosition; //���� ��ġ(x) ����

    float leftm;
    float rightm;

    private Transform currentTransform;

    float direction = 3.0f; //�̵��ӵ�+����



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
            Debug.Log("����̵�");
            direction *= -1;

            currentPosition = rightm;

        }

        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPosition <= leftm)

        {
            Debug.Log("�·��̵�");
            direction *= -1;

            currentPosition = leftm;

        }

        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

        transform.position = new Vector3(currentPosition, 0, 0);

        //"Stone"�� ��ġ�� ���� ������ġ�� ó��
    }
}