using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public bool TurnPoint;
    public float moveSpeed;
    public float initPositionY;
    public float turningPoint;
    public float distance;

    void Awake()
    {
        initPositionY = transform.position.y;
        turningPoint = initPositionY - distance;
    }
    void Update()
    {
        UpDown();
    }

    void UpDown()
    {
        float currentPositionY = transform.position.y;
        if (currentPositionY >= initPositionY)
        {
            TurnPoint = false;
        }
        else if (currentPositionY <= turningPoint)
        {
            TurnPoint = true;
        }

        if (TurnPoint)
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        }
    }

}
