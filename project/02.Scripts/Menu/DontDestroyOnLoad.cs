using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    Scene scene;
    //private static DontDestroyOnLoad s_Instance = null;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Keep");

        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
 /*       if (s_Instance)
        {
            Destroy(this.gameObject);

        }
        else
        {
            s_Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }*/
        

    }
}
