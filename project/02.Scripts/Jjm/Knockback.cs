using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force = 10f; // �˹��� ����
    public float radius = 5f; // �浹 üũ �ݰ�
    public float upwardsModifier = 1f; // ���� ���� ���ϴ� ����

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �浹�� ������Ʈ�� "Enemy" �±׸� ���� ��쿡�� �˹��� ����
        {
            Vector3 direction = collision.contacts[0].point - transform.position; // �浹 ������ �������� �˹� ���� ���� ���
            direction = direction.normalized; // ���� ���� ����ȭ
            float distance = Vector3.Distance(transform.position, collision.contacts[0].point); // �浹 �������� �Ÿ� ���
            float impactForce = force / distance; // �Ÿ��� ���� �� ���
            Vector3 knockbackForce = direction * impactForce; // �˹� �� ���
            knockbackForce.y *= upwardsModifier; // ���� ���� ���ϴ� ���� ����
            rb.AddForce(knockbackForce, ForceMode.Impulse); // �˹� ����
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
