using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSave : MonoBehaviour
{
    public List<bool> savepoint;
    GameObject player;

    // Start is called before the first frame update
    private void Awake()
    {
        savepoint= new List<bool>() {false,false,false,false};
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
