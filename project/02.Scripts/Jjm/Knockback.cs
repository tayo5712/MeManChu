using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force = 10f; // 넉백의 세기
    public float radius = 5f; // 충돌 체크 반경
    public float upwardsModifier = 1f; // 위로 힘을 가하는 비율

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 충돌한 오브젝트가 "Enemy" 태그를 가진 경우에만 넉백을 적용
        {
            Vector3 direction = collision.contacts[0].point - transform.position; // 충돌 지점을 기준으로 넉백 방향 벡터 계산
            direction = direction.normalized; // 방향 벡터 정규화
            float distance = Vector3.Distance(transform.position, collision.contacts[0].point); // 충돌 지점과의 거리 계산
            float impactForce = force / distance; // 거리에 따른 힘 계산
            Vector3 knockbackForce = direction * impactForce; // 넉백 힘 계산
            knockbackForce.y *= upwardsModifier; // 위로 힘을 가하는 비율 적용
            rb.AddForce(knockbackForce, ForceMode.Impulse); // 넉백 적용
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
