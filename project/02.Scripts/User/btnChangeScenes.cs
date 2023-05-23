using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnChangeScenes : MonoBehaviour
{
    public GameObject LogInLayer;
    public GameObject SignUpLayer;


    
    public void logIntoSignUp()
    {
        LogInLayer.SetActive(false);
       
        SignUpLayer.SetActive(true);
    }

    public void signUptoLogIn()
    {
        SignUpLayer.SetActive(false);
        LogInLayer.SetActive(true);
    }
}
