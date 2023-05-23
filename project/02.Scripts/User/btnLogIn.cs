using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class btnLogIn : MonoBehaviour
{

    public TMP_InputField inputID;
    public TMP_InputField inputPW;
    public TMP_Text text;
    string ID;
    string PW;

    public void logIn()
    {
        text.SetText("");
        ID = inputID.GetComponent<TMP_InputField>().text;
        PW = inputPW.GetComponent<TMP_InputField>().text;
        
        if (ID.Length <= 0)
        {
            Debug.Log("please enter your ID");
            text.SetText("please enter your ID");
            return;
        }
        if (PW.Length <= 0) {
            Debug.Log("please enter your PW");
            text.SetText("please enter your ID");
            return;
        }

        StartCoroutine(REST.postLogIn(new USER(ID, "", PW), text));
        //PlayerPrefs.SetString("ID", ID);
        //PlayerPrefs.SetString("NAME", ID);
        //SceneManager.LoadScene("Loading");
    }
}
