using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    private float distance = 6.0f;
    [SerializeField]
    private float height;
    [SerializeField]
    private float rotationDamping;
    [SerializeField]
    private float heightDamping;
    private float mouseY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (!target)
            return;
        mouseY = Input.GetAxis("Mouse Y");

        height -= mouseY;
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + Mathf.Clamp(height,1f,2f);

        var currentRotationsAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        currentRotationsAngle = Mathf.LerpAngle(currentRotationsAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, currentRotationsAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(target);
    }
}
