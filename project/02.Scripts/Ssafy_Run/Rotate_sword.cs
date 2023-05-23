using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_sword : MonoBehaviour
{
    public int speed = 300;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.fwd * speed * Time.deltaTime);
    }
}
