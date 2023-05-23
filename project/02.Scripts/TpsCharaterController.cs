using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsCharaterController : MonoBehaviour
{
    [SerializeField]
    private GameObject charaterBody;
    [SerializeField]
    private Transform cameraArm;


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        charaterBody = GameObject.FindGameObjectWithTag("Player");
        animator = charaterBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
        charaterBody.transform.forward = lookForward;
        animator.SetBool("isMove", isMove);
        if (isMove)
        {

            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            transform.position += moveDir * Time.deltaTime * 5f;
        }
    }


    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }


        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);

    }
}
