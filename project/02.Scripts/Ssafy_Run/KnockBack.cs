using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // ��ü�� ƨ�� �� ���� ���� ũ��
    public float bounceForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Rigidbody ������Ʈ ��������
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        // �浹�� ������Ʈ�� Rigidbody�� �����ϴ� ���
        if (rb != null)
        {
            // �浹�� ������Ʈ�� �������� ���� ���ؼ� ƨ�ܳ������� ��
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = -direction.normalized;
            rb.AddForce(direction * bounceForce, ForceMode.Impulse);
        }
    }
}