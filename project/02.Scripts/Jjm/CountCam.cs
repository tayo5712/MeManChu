using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCam : MonoBehaviour
{
    public GameObject Cam;

    void Update()
    {
        transform.rotation = Cam.transform.rotation;
    }
}
