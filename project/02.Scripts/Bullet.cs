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
        
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ٵ��� �ӵ� = dkvWhrqkdgid ���ʹ��� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward* speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
        
    }

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player") 
        {
            Debug.Log("�÷��̾� ��Ʈ��Ʈ");
            ThirdPersonController players= other.GetComponent<ThirdPersonController>();
            

            Debug.Log(players.currentHealth);
            if (players != null) 
            {
                Destroy(gameObject);
                players.currentHealth -= 10;
            }
/*            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController= other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }*/
        }
    }
}
