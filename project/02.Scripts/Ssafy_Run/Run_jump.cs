using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // ������ ��
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (playerRigidbody != null) // �÷��̾ Rigidbody ������Ʈ�� �����ϴ� ���
        {
            Vector3 jumpVector = transform.up * jumpForce; // ������ ����� ���� ���
            playerRigidbody.AddForce(jumpVector, ForceMode.Impulse); // ����
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null) // �÷��̾ Rigidbody ������Ʈ�� �����ϴ� ���
            {
                Vector3 jumpVector = transform.up * jumpForce; // ������ ����� ���� ���
                playerRigidbody.AddForce(jumpVector, ForceMode.Impulse); // ����
            }
        }
    }
}
