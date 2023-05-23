using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueKeycheck : MonoBehaviour
{

    public int bluekey = 0;
    public GameObject keylock1;
    public GameObject NPCDialog;
    public GameObject NPCText;

    public int val = 0;

    private void Start()
    {
        keylock1 = GameObject.Find("keylock1");
        
    }


    private void Update()
    {
        

        if ( bluekey == 1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
               
                    NPCDialog = GameObject.Find("NPCDialog2");
                    GameObject.Find("NPCText2").GetComponent<Text>().text = "";
                    NPCDialog.SetActive(false);
                    

                    GameObject.Find("keylock1").GetComponent<NPCtrigger10>().ChatText = "<color=#ff7777>[시스템]</color>파랑 열쇠로 <size=20><color=#ffff33></color></size> 문을 열었습니다!";
                    Object.Destroy(GameObject.Find("1Door"));
                    Object.Destroy(GameObject.Find("DoorLock"));
                    Object.Destroy(GameObject.Find("1FCube2"));
                    Object.Destroy(GameObject.Find("questionmarkb"));



            }
            else
            {
                GameObject.Find("keylock1").GetComponent<NPCtrigger10>().ChatText = "<color=#ff7777>[시스템]</color>파랑 열쇠로 문을 여시려면 <size=20><color=#ffff33></color></size> K 를 누르세요!";
            }
        }
    }


}
