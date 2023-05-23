using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunAgain : MonoBehaviour
{
    GameObject player;
    private Run_stopwatch death;

    private void Awake()
    {
        /*player = GameObject.FindGameObjectWithTag("Player");*/
       /* GameObject.FindGameObjectWithTag("Player").GetComponent<RunSave>().savepoint;*/

    }
    private void Start()
    {
        death = GameObject.Find("Plane").GetComponent<Run_stopwatch>(); 
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        death.deathcount++;
        
            if (other.gameObject.GetComponent<RunSave>().savepoint[3] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -3f;
                originPoint.y = 119f;
                originPoint.z = -139f;
                other.transform.position = originPoint;
            }
            else if (other.gameObject.GetComponent<RunSave>().savepoint[2] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -227f;
                originPoint.y = 43f;
                originPoint.z = -33f;
            other.transform.position = originPoint;
            }
            else if (other.gameObject.GetComponent<RunSave>().savepoint[1] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -225f;
                originPoint.y = 38f;
                originPoint.z = 230f;
            other.transform.position = originPoint;
            }
            else if (other.gameObject.GetComponent<RunSave>().savepoint[0] == true)
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = -20f;
                originPoint.y = 9f;
                originPoint.z = 235f;
            other.transform.position = originPoint;
            }
            else
            {
                Vector3 originPoint = new Vector3();
                originPoint.x = 0f;
                originPoint.y = 0.5f;
                originPoint.z = 0f;
            other.transform.position = originPoint;
            }
           
            print(other.gameObject.GetComponent<RunSave>().savepoint[1] +"гоюл");
        
    }
}
