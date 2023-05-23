using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offset;
    SphereCollider sphereCollider;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        /*sphereCollider = GetComponent<SphereCollider>(); */
    }

    void Start()
    {
        /*gameObject.SetActive(false);*/
        /*Invoke("OrbitOff", 10f);*/
        /*StartCoroutine(SwitchOff());*/
    }

    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position,
                                Vector3.up,
                                orbitSpeed * Time.deltaTime);
        /*offset = transform.position - target.position;*/
    }

    /*  void OrbitOff()
      {
          gameObject.SetActive(false);
      }*/

    /*IEnumerator SwitchOff()
    {
        Debug.Log("llllll");
        gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);

        Debug.Log("dddddd");
        gameObject.SetActive(false);
        Debug.Log("zzzzzzzzzzzzzz");
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("dlddld");
            Vector3 reactVec = transform.position - other.transform.position;



        }
    }
}
