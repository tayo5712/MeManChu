using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace act
{
    public class handkerget : MonoBehaviour
    {


        // public GameObject rangeOb; //�� ������Ʈ(Position), ���� ������Ʈ�ޱ�
        // CircleCollider2D rangeCol; //�� ������Ʈ(Position)�� CircleCollider2D ��������

        //  public GameObject circle; //��ȯ�� ���� ���׶�̵�

        //  private void Awake() //update�� �Ⱦ��� ������ Start�� �ȸ��� == Awake����
        //  {
        //      rangeCol = rangeOb.GetComponent<CircleCollider2D>(); // �������Ʈ�� CircleCollider2D �޾ƿ���
        //  }


        // public GameObject cube1;
        //public GameObject Jammo2;
        // private float Dist;

        

        private void OnTriggerEnter(Collider other)
        {

            Debug.Log(" �ռ��� ȹ�� ! ");
         //   Destroy(gameObject);
            GameObject.Find("Sinked").GetComponent<washedHandkerget>().handobject = 1;


        }


        /*
        private void OnMouseDown() // ���콺�� Ŭ�������� �����, �ݶ��̴� ������ �ȵ�
        {
            Vector2 originpo = rangeOb.transform.position; //���� �� ������Ʈ�� ��ġ�� ��������
            int pota = Random.Range(1, 10); //1���� 10���� ������
            Dist = Vector3.Distance(cube1.transform.position, Jammo2.transform.position);
            Debug.Log("Ŭ���� ������Ʈ : " + gameObject.name);

            if (Dist < 7)
            {
                Debug.Log("hi");
                SceneManager.LoadScene("JDHLobby");
            }


        }*/

    }
}