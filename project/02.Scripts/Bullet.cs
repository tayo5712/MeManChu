using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = dkvWhrqkdgid 앞쪽방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward* speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
        
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player") 
        {
            Debug.Log("플레이어 히트히트");
            ThirdPersonController players= other.GetComponent<ThirdPersonController>();
            

            Debug.Log(players.currentHealth);
            if (players != null) 
            {
                Destroy(gameObject);
                players.currentHealth -= 10;
            }
/*            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController= other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }*/
        }
    }
}
