using UnityEngine;

public class Run_ping : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 10f; // 캐릭터를 날려버리는 힘의 크기
    [SerializeField] private float knockbackDuration = 0.2f; // 캐릭터가 날려져 있는 시간
    [SerializeField] private float knockbackHeight = 2f; // 캐릭터가 날려져 있는 높이

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인 경우
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null) // 플레이어의 Rigidbody가 존재하는 경우
            {
                // 캐릭터를 knockbackDuration 동안 knockbackHeight 높이만큼 올려주고 knockbackForce의 힘을 줌
                playerRb.AddForce(transform.forward * knockbackForce + Vector3.up * knockbackHeight, ForceMode.Impulse);

                // 일정 시간 후 캐릭터를 다시 땅으로 내려줌
                Invoke("ResetPlayerVelocity", knockbackDuration);
            }
        }
    }

    private void ResetPlayerVelocity()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}