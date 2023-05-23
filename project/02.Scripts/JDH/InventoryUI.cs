using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanal;
    bool activeInventory = false;

    private void Start()
    {
        inventoryPanal.SetActive(activeInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activeInventory = !activeInventory;
            inventoryPanal.SetActive(activeInventory);
        }
    }



}
