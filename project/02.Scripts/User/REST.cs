using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json;
using System.Text;
using System.Collections;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;

public class RESULT
{
    public bool success;
    public int index;
    public string message;
    public string status;
    public string name;
    public RANK[] ranks;
}

[System.Serializable]
public class USER
{
    public string ID;
    public string NAME;
    public string PASS;

    public USER(string id, string name, string pw)
    {
        ID = id;
        NAME = name;
        PASS = pw;
    }

    public USER()
    {

    }
}

[System.Serializable]
public class RANK
{
    public string id;
    public string name;
    public string map;
    public string time;
    public string score;
    public string date;

    public RANK(string i, string n, string m, string t)
    {
        id = i;
        name = n;
        map = m;
        time = t;
    }

    public RANK()
    {

    }
}

[System.Serializable]
public class EMAIL
{
    public string email;

    public EMAIL(string e)
    {
        email = e;
    }

    public EMAIL()
    {

    }
}

public class VERSION
{
    public string version;

    public VERSION()
    {
        version = "1.0";
    }
}
public class REST : MonoBehaviour
{
    public static float cnt = 5;

    // "/api/signup"
    static public IEnumerator postSignUp(USER user, TMP_Text t, Action<int> setset)
    {
        string json = JsonUtility.ToJson(user);
        return postSignUp("/signup", json, t, setset);
    }

    // "/api/login"
    static public IEnumerator postLogIn(USER user, TMP_Text text)
    {
        PlayerPrefs.SetString("ID", user.ID);
        string json = JsonUtility.ToJson(user);

        return postLog("/login", json, text);
    }

    // "/api/ranksins"
    static public IEnumerator postRankIns(RANK rank)
    {
        string json = JsonUtility.ToJson(rank);

        return post("/ranksins", json);
    }

    // "/api/email"
    static public IEnumerator postEmail(EMAIL email)
    {
        string json = JsonUtility.ToJson(email);

        return postEmail("/email", json);
    }

    // "/api/ranks/:map"
    static public IEnumerator getRanks_Map(string map, Action<RESULT> callbackf, bool state = true)
    {
        string temp = state ? $"/ranks?map={map}" : $"/ranksd?map={map}";
        return get(temp, callbackf);
    }

    //// "/api/login/:id"
    //public void getUser_Name(string id)
    //{
    //    StartCoroutine(get($"/login?id={id}"));
    //}
    static public IEnumerator checkVersion()
    {
        string json = JsonUtility.ToJson(new VERSION());

        return postMsg("/version", json);
    }

    static IEnumerator postMsg(string url, string json)
    {
        using (UnityWebRequest www = new UnityWebRequest("https://j8c210.p.ssafy.io/api" + url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                RESULT result = new RESULT();
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, result);

                if (result.success)
                {

                }
                else
                {
                    Application.Quit();
                }
                Debug.Log(www.downloadHandler.text);

            }
        }
    }
    static IEnumerator get(string url, Action<RESULT> callbackf)
    {
        Debug.Log("Call get");

        using (UnityWebRequest www = UnityWebRequest.Get("https://j8c210.p.ssafy.io/api" + url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                RESULT result = new RESULT();
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, result);
                callbackf(result);
                //Debug.Log(www.downloadHandler.text);
                //Debug.Log("get request complete!");
            }
        }
    }

    static IEnumerator postLog(string url, string json, TMP_Text text)
    {
        Debug.Log("Call post");
        Debug.Log(json);
        using (UnityWebRequest www = new UnityWebRequest("https://j8c210.p.ssafy.io/api" + url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                RESULT result = new RESULT();
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, result);

                if (result.success)
                {
                    Debug.Log("로그인 성공");
                    SceneManager.LoadScene("Loading");
                    Debug.Log(result.name);
                    PlayerPrefs.SetString("NAME", result.name);
                    // 캔버스 종료해야댐
                }
                else
                {
                    text.text = "LogIn Failed";
                }
                Debug.Log(www.downloadHandler.text);
                //if (result.success == true) {
                //       Debug.Log("로그인 성공");
                //  }

            }
        }
    }

    static IEnumerator post(string url, string json)
    {
        Debug.Log("Call post");
        Debug.Log(json);
        using (UnityWebRequest www = new UnityWebRequest("https://j8c210.p.ssafy.io/api" + url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                RESULT result = new RESULT();
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, result);
                Debug.Log(www.downloadHandler.text);


            }
        }
    }

    static IEnumerator postSignUp(string url, string json, TMP_Text t, Action<int> setset)
    {
        Debug.Log("Call post");
        Debug.Log(json);
        using (UnityWebRequest www = new UnityWebRequest("https://j8c210.p.ssafy.io/api" + url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                RESULT result = new RESULT();
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, result);
                t.SetText(result.message.Substring(10));
                Debug.Log(www.downloadHandler.text);
                setset(2);
            }
        }
    }

    static IEnumerator postEmail(string url, string json)
    {
        Debug.Log("Call post");
        Debug.Log(json);
        using (UnityWebRequest www = new UnityWebRequest("https://j8c210.p.ssafy.io/api" + url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                RESULT result = new RESULT();
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, result);

                if (result.success)
                {
                    Debug.Log(www.downloadHandler.text);
                    PlayerPrefs.SetString("number", result.message);
                }
            }
        }
    }
}
