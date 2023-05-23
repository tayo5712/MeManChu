using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Water;

public class Tile : MonoBehaviour
{
    GameObject player;
    Material mat;

    GameObject TileF;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mat = GetComponent<MeshRenderer>().material;
        /*TileF = GameObject.FindGameObjectWithTag("Tile");*/
        /*TileF = GameObject.Find("Tile_1_base");*/
        /*mat = TileF.GetComponent<MeshRenderer>().material;*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*Debug.Log("asd");*/
            /*gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.FindWithTag("Crush").GetComponent<Renderer>().material.color = Color.red;*/

            Invoke("TileOff", 1f);

            /*mat = TileF.GetComponent<MeshRenderer>().material;*/

            /*StartCoroutine(ChangeCol());*/
        }
    }

    /*IEnumerator ChangeCol()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }*/

    void TileOff()
    {
        gameObject.SetActive(false);
    }
}
