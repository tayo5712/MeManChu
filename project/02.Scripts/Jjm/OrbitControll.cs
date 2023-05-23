using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControll : MonoBehaviour
{
    public GameObject FindOrbit;
    void Start()
    {
        FindOrbit = GameObject.Find("Funny Group");
    }
    public void OrbitChange(Orbit value)
    {
       /* StartCoroutine(SwitchOff());*/
    }

    /*IEnumerator SwitchOff()
    {
        Debug.Log("llllll");
        FindOrbit.SetActive(true);
        yield return new WaitForSeconds(10f);

        Debug.Log("dddddd");
        FindOrbit.SetActive(false);
        Debug.Log("zzzzzzzzzzzzzz");
    }*/
}
