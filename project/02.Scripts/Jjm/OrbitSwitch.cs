using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSwitch : MonoBehaviour
{
    GameObject player;
    public GameObject orbitSwitch;
    public GameObject gimic;
    public GameObject speedFind;
    ThirdPersonController speedControl;
    public GameObject orbitFind;
    public Orbit orbitControl;

    float currTime;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        /*orbitSwitch = GameObject.FindObjectOfType<GameObject>();*/
    }


    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > 5)
        {
            float newX = Random.Range(-10f, 10f), newY = 0.5f, newZ = Random.Range(-10f, 10f);
            GameObject button = Instantiate(orbitSwitch);
            button.transform.position = new Vector3(newX, newY, newZ);

            currTime= 0;
        }
        /*Destroy(orbitSwitch, 6);*/
        /*Invoke("OrbitSwitchOff", 6f);*/
    }

   /* void OrbitSwitchOff()
    {
        orbitSwitch.SetActive(false);
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            /*gimic.gameObject.SetActive(true);*/
            StopCoroutine(SwitchOff());
            StartCoroutine(SwitchOff());
            speedControl = other.GetComponent<ThirdPersonController>();
            speedFind.GetComponent<SpeedControll>().SpeedChange(speedControl);
            /*orbitControl = other.GetComponent<Orbit>();
            orbitFind.GetComponent<OrbitControll>().OrbitChange(orbitControl);*/
        }
        Destroy(orbitSwitch);
    }

    IEnumerator SwitchOff()
    {
        Debug.Log("llllll");
        gimic.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(10f);

        Debug.Log("dddddd");
        gimic.gameObject.SetActive(false);
        Debug.Log("zzzzzzzzzzzzzz");
    }
}
