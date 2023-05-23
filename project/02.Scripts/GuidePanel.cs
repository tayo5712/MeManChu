using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanel : MonoBehaviour
{
    public GameObject panelObject;

    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ClosePanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panelObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        panelObject.SetActive(true);    
    }

    private void ClosePanel()
    {
        panelObject.SetActive(false);
    }


}
