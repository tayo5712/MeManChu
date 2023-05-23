using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objget : MonoBehaviour
{
    public GameObject rangeOb; //�� ������Ʈ(Position), ���� ������Ʈ�ޱ�
    CircleCollider2D rangeCol; //�� ������Ʈ(Position)�� CircleCollider2D ��������

    public GameObject circle; //��ȯ�� ���� ���׶�̵�

    private void Awake() //update�� �Ⱦ��� ������ Start�� �ȸ��� == Awake����
    {
        rangeCol = rangeOb.GetComponent<CircleCollider2D>(); // �������Ʈ�� CircleCollider2D �޾ƿ���
    }


    public GameObject Basketball;
    public GameObject Jammo;
    private float Dist;
    private void OnMouseDown() // ���콺�� Ŭ�������� �����, �ݶ��̴� ������ �ȵ�
    {
        Dist = Vector3.Distance(Basketball.transform.position, Jammo.transform.position);
        Vector2 originpo = rangeOb.transform.position; //���� �� ������Ʈ�� ��ġ�� ��������
        int pota = Random.Range(1, 10); //1���� 10���� ������
        Debug.Log("Ŭ���� ������Ʈ : " + gameObject.name);

        //Debug.Log(Dist);
        if (Dist < 17)
        {
            SceneManager.LoadScene("new3");
        }

    }


}