using StarterAssets;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire_2to1 : MonoBehaviour
{

    //플레이어 안의 내용물 가져오기
    private GameObject user;
    private Transform PlayerTransForm;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerTransForm = other.GetComponent<Transform>();
            PlayerTransForm.position = new Vector3(9.714f, 1.1f, 0.416f);
            SceneManager.LoadScene("Fire_1");
        }
    }
}