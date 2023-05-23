using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGiant : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("haha");
        SceneManager.LoadScene("Giantroom");
    }


}
