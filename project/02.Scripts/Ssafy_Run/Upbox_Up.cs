using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upbox_Up : MonoBehaviour
{
    float initPositionY;
    public float distance;
    public float turningPoint;

    private bool turnSwitch;
    public float moveSpeed;

    void Awake()
    {
        if (gameObject.tag == "UD_Floor")
        {
            initPositionY = transform.position.y;
            turningPoint = initPositionY + distance;
        }
    }

    void upDown ()
    {
        float currentPositionY = transform.position.y;

        if (currentPositionY <= initPositionY)
        {
            turnSwitch= false;
        }
        else if (currentPositionY >= turningPoint)
        {
            turnSwitch= true;
        }

        if (turnSwitch )
        {
            transform.position = transform.position - new Vector3(0,1,0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position - new Vector3(0, -1,0)* moveSpeed * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (gameObject.tag == "UD_Floor")
        {
            upDown();
        }
    }

}
