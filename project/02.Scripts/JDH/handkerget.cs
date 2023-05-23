using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace act
{
    public class handkerget : MonoBehaviour
    {


        // public GameObject rangeOb; //빈 오브젝트(Position), 하위 오브젝트받기
        // CircleCollider2D rangeCol; //빈 오브젝트(Position)의 CircleCollider2D 가져오기

        //  public GameObject circle; //소환될 작은 동그라미들

        //  private void Awake() //update를 안쓰기 때문에 Start가 안먹힘 == Awake쓰기
        //  {
        //      rangeCol = rangeOb.GetComponent<CircleCollider2D>(); // 빈오브젝트의 CircleCollider2D 받아오기
        //  }


        // public GameObject cube1;
        //public GameObject Jammo2;
        // private float Dist;

        

        private void OnTriggerEnter(Collider other)
        {

            Debug.Log(" 손수건 획득 ! ");
         //   Destroy(gameObject);
            GameObject.Find("Sinked").GetComponent<washedHandkerget>().handobject = 1;


        }


        /*
        private void OnMouseDown() // 마우스로 클릭했을때 실행됨, 콜라이더 없으면 안됨
        {
            Vector2 originpo = rangeOb.transform.position; //지금 빈 오브젝트의 위치값 가져오기
            int pota = Random.Range(1, 10); //1부터 10까지 랜덤값
            Dist = Vector3.Distance(cube1.transform.position, Jammo2.transform.position);
            Debug.Log("클릭된 오브젝트 : " + gameObject.name);

            if (Dist < 7)
            {
                Debug.Log("hi");
                SceneManager.LoadScene("JDHLobby");
            }


        }*/

    }
}