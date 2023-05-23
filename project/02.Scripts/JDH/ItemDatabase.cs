using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;

    }
    public List<Item> itemDB = new List<Item>();
    [Space(20)]
    public GameObject filedItemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        for (int i = 0; i < 6; i++) {
          GameObject go = Instantiate(filedItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 2)]);  
        }
    }




    


}
