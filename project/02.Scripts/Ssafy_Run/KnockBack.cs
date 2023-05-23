using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // 물체가 튕길 때 가할 힘의 크기
    public float bounceForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 Rigidbody 컴포넌트 가져오기
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        // 충돌한 오브젝트에 Rigidbody가 존재하는 경우
        if (rb != null)
        {
            // 충돌한 오브젝트의 방향으로 힘을 가해서 튕겨나가도록 함
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = -direction.normalized;
            rb.AddForce(direction * bounceForce, ForceMode.Impulse);
        }
    }
}