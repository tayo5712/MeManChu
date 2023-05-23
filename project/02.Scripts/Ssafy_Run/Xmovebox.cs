using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xmovebox : MonoBehaviour
{
    float initPositionX;
    public float distance;
    public float turningPoint;

    private bool turnSwitch;
    public float moveSpeed;

    void Awake()
    {
        if (gameObject.tag == "Left_Floor")
        {
            initPositionX = transform.position.x;
            turningPoint = initPositionX - distance;
        }
    }

    void leftright()
    {
        float currentPositionX = transform.position.x;

        if (currentPositionX >= initPositionX)
        {
            turnSwitch = false;
        }
        else if (currentPositionX <= turningPoint)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (gameObject.tag == "Left_Floor")
        {
            leftright();
        }
    }

}
