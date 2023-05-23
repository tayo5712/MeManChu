using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public GameObject Crow;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            if (player.hasGarretKey)
            {
                player.accessText.text = "'E'키를 눌러서 문을 여세요.";
                player.accessText.gameObject.SetActive(true);
                if (player.eDown && player.hasGarretKey)
                {
                    door.GetComponent<garretDoor>().Open(player);
                    Destroy(door.transform.Find("DoorRange").gameObject);
                    player.accessText.gameObject.SetActive(false);
                    Crow.GetComponent<crow>().audioSource.Play();
                }
            }
            else
            {
                player.accessText.text = "다락방 열쇠가 없습니다.";
                player.accessText.color = Color.red;
                player.accessText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorPlayer player = other.GetComponent<horrorPlayer>();
            player.accessText.gameObject.SetActive(false);
            player.accessText.color = Color.white;
        }
    }
}
