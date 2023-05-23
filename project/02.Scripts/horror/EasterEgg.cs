using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public GameObject ConnectObject;

    void Start()
    {
        
    }
    void Update()
    {
        Debug.Log("11");
        ConnectDone();
    }
    
    void ConnectDone()
    {
        FallDown fallDown = ConnectObject.GetComponent<FallDown>();
        Debug.Log(fallDown.isDone);
        if (fallDown.isDone == true)
        {
            StartCoroutine(PlayEvent());
        }    
    }

    IEnumerator PlayEvent()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
