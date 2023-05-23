using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

namespace userController
{
    public class signUpPush : MonoBehaviour
    {

        public TMP_InputField inputID;
        public TMP_InputField inputPW;
        public TMP_InputField inputName;
        public TMP_InputField inputEmail;
        public TMP_InputField inputNumber;
        public TMP_Text Text;
        public GameObject LogInLayer;
        public GameObject SignUpLayer;

        string ID;
        string PW;
        string Name;
        string Email;
        string Number;

        public void SignUp()
        {
            ID = inputID.GetComponent<TMP_InputField>().text;
            PW = inputPW.GetComponent<TMP_InputField>().text;
            Name = inputName.GetComponent<TMP_InputField>().text;
            Number = inputNumber.GetComponent<TMP_InputField>().text;

            if(ID.Length <= 0)
            {
                Debug.Log("please enter your ID!");
                Text.SetText("please enter your ID!");
                return;
            }
            if (ID.Length < 4)
            {
                Debug.Log("ID is too short!");
                Text.SetText("ID is too short!");
                return;
            }
            if (PW.Length <= 0)
            {
                Debug.Log("please enter your PW!");
                Text.SetText("please enter your PW!");
                return;
            }
            if (Name.Length <= 0)
            {
                Debug.Log("please enter your Name");
                Text.SetText("please enter your Name!");
                return;
            }
            if (PW.Length < 8)
            {
                Debug.Log("password is too short!");
                Text.SetText("password is too short!");
                return;
            }
            if (Number.Length <= 0)
            {
                Debug.Log("please enter your Number");
                Text.SetText("please enter your Number!");
                return;
            }
            if (Number.Length < 6)
            {
                Debug.Log("number is too short!");
                Text.SetText("number is too short!");
                return;
            }
            if (Number.Length > 6)
            {
                Debug.Log("number is too long!");
                Text.SetText("number is too long!");
                return;
            }
            if (!PlayerPrefs.GetString("number").ToString().Equals(Number)) {
                Debug.Log("number is wrong");
                Text.SetText("number is wrong!");
                return;
            }
    
            StartCoroutine(REST.postSignUp(new USER(ID, Name, PW), Text, setset));
        }

        public void setset(int a)
        {
            SignUpLayer.SetActive(false);
            LogInLayer.SetActive(true);
        }

        public bool IsValidEmail(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }

        public void Send()
        {
            Email =  inputEmail.GetComponent<TMP_InputField>().text;
            if (!IsValidEmail(Email))
            {
                Text.SetText("email is wrong!");
                return;
            }
            Text.SetText("number has been sent!");
            StartCoroutine(REST.postEmail(new EMAIL(Email)));
        }
    }
}