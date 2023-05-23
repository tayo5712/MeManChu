using UnityEngine;

public class Run_ping : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 10f; // ĳ���͸� ���������� ���� ũ��
    [SerializeField] private float knockbackDuration = 0.2f; // ĳ���Ͱ� ������ �ִ� �ð�
    [SerializeField] private float knockbackHeight = 2f; // ĳ���Ͱ� ������ �ִ� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null) // �÷��̾��� Rigidbody�� �����ϴ� ���
            {
                // ĳ���͸� knockbackDuration ���� knockbackHeight ���̸�ŭ �÷��ְ� knockbackForce�� ���� ��
                playerRb.AddForce(transform.forward * knockbackForce + Vector3.up * knockbackHeight, ForceMode.Impulse);

                // ���� �ð� �� ĳ���͸� �ٽ� ������ ������
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