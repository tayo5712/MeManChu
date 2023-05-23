using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(goLogin());
    }

    // Update is called once per frame
    IEnumerator goLogin()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TESTGO");
    }
}
