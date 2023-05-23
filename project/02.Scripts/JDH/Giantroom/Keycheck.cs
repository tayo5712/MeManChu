using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keycheck : MonoBehaviour
{

    public int greenkey = 0;
    public GameObject opendoor;
    public GameObject opendoor2;
    public GameObject NPCDialog;
    public int val = 0;
    

    private void Start()
    {
        
        // keylock1 = GameObject.Find("keylock1");
    }


    private void Update()
    {
        greenkey = GameObject.Find("Padlock").GetComponent<NPCtrigger11>().greenkey;


        if (val == 1)
        {
            if (greenkey == 1)
            {

                if (Input.GetKeyDown(KeyCode.K))
                {
                    Object.Destroy(GameObject.Find("Padlock"));
                    Object.Destroy(GameObject.Find("closedoor"));
                    Object.Destroy(GameObject.Find("cabi"));
                    Object.Destroy(GameObject.Find("cabiq"));
                    GameObject.Find("NPCDialog2").SetActive(false);
                    GameObject.Find("NPCText2").GetComponent<Text>().text = "";
                    GameObject.Find("quiz1box2").GetComponent<BoxCollider>().isTrigger = true;

                }
            }
        }
    }
    
    

}
