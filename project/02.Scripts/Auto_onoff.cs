using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_onoff : MonoBehaviour
{
    private float time;
    private int count;
    private MeshRenderer len;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        count = 0;
        len = FindObjectOfType<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f && count == 0)
        {
            len.enabled= false;
            count = 1;
            time = 0f;
        }
        else if (time >= 3f && count == 1)
        {
            len.enabled = true;
            count = 0;
            time = 0f;
        }
        Debug.Log(time);
        Debug.Log(count);
    }
}
