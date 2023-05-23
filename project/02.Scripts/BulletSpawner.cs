using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ źȯ�� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; // �ֱٻ��� �������� ���� �ð�

    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ź�� ���� ������ ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<ThirdPersonController>().transform;

    }
    void Update()
    {
        // ���� �ð� ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� �������� ���� ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���Ƹ�
        if (timeAfterSpawn >= spawnRate )
        {
            // ������ �ð��� ����
            timeAfterSpawn= 0f;

            //źȯ�� �������� transform.position ��ġ�� transform.ratation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ źȯ�� ���� ������Ʈ�� ���� ������ Ÿ���� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            // ������ ���� ������ �������� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
