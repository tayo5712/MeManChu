using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace act
{

    public class washedHandkerget : MonoBehaviour
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

        public int handobject;
        private GameObject NPCDialog;
        private Text NPCText;

        private void OnTriggerEnter(Collider other)
        {   
              if (handobject == 1)
              {
                Debug.Log(" ���� �ռ��� ȹ�� ! ");
                GameObject.Find("Portalto2").GetComponent<Portal_to_2>().washed = 1;
                NPCDialog = GameObject.Find("NohandDialog");
                
                GameObject.Find("Sinked").GetComponent<NPCtrigger>().ChatText = "<color=#ff7777>[�޽���]</color> <size=20><color=#ffff33> ���� �ռ��� ȹ�� ! </color></size>";
                NPCText = GameObject.Find("NohandText").GetComponent<Text>();
                NPCDialog.SetActive(true);
            }
             else {
                Debug.Log(handobject + " �ռ����� �ʿ��մϴ�. ");
                NPCDialog = GameObject.Find("NohandDialog");
                GameObject.Find("Sinked").GetComponent<NPCtrigger>().ChatText = "<color=#ff7777>[�޽���]</color> <size=20><color=#ffff33> �ռ����� �ʿ��մϴ� ! </color></size>";
                NPCText = GameObject.Find("NohandText").GetComponent<Text>();
                NPCDialog.SetActive(true);
             }
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