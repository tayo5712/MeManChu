using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // 점프할 힘
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (playerRigidbody != null) // 플레이어에 Rigidbody 컴포넌트가 존재하는 경우
        {
            Vector3 jumpVector = transform.up * jumpForce; // 점프할 방향과 힘을 계산
            playerRigidbody.AddForce(jumpVector, ForceMode.Impulse); // 점프
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인 경우
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null) // 플레이어에 Rigidbody 컴포넌트가 존재하는 경우
            {
                Vector3 jumpVector = transform.up * jumpForce; // 점프할 방향과 힘을 계산
                playerRigidbody.AddForce(jumpVector, ForceMode.Impulse); // 점프
            }
        }
    }
}
