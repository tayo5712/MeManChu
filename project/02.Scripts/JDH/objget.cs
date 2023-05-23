using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objget : MonoBehaviour
{
    public GameObject rangeOb; //빈 오브젝트(Position), 하위 오브젝트받기
    CircleCollider2D rangeCol; //빈 오브젝트(Position)의 CircleCollider2D 가져오기

    public GameObject circle; //소환될 작은 동그라미들

    private void Awake() //update를 안쓰기 때문에 Start가 안먹힘 == Awake쓰기
    {
        rangeCol = rangeOb.GetComponent<CircleCollider2D>(); // 빈오브젝트의 CircleCollider2D 받아오기
    }


    public GameObject Basketball;
    public GameObject Jammo;
    private float Dist;
    private void OnMouseDown() // 마우스로 클릭했을때 실행됨, 콜라이더 없으면 안됨
    {
        Dist = Vector3.Distance(Basketball.transform.position, Jammo.transform.position);
        Vector2 originpo = rangeOb.transform.position; //지금 빈 오브젝트의 위치값 가져오기
        int pota = Random.Range(1, 10); //1부터 10까지 랜덤값
        Debug.Log("클릭된 오브젝트 : " + gameObject.name);

        //Debug.Log(Dist);
        if (Dist < 17)
        {
            SceneManager.LoadScene("new3");
        }

    }


}