using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Safe : MonoBehaviour
{
    public RectTransform SafeGroup;
    public string password;
    horrorPlayer player;
    public GameObject SafeDoor;
    public GameObject SafeHandle;
    public GameObject CellarKey;
    AudioSource audioSource;
    public AudioClip unLockSound;
    bool isOpen;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            player = other.GetComponent<horrorPlayer>();
            player.accessText.text = "안에 뭔가 있는 것 같다. 확인해 보자";
            player.accessText.gameObject.SetActive(true);

            if (player.eDown)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                player.moveFalse();
                SafeGroup.anchoredPosition = Vector3.zero;
                player.accessText.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            password = "";
            SafeGroup.anchoredPosition = Vector3.down * 1000;
            player.moveTrue();
            player.accessText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        PassWordCheck();
    }

    void PassWordCheck()
    {
        if (!isOpen)
        {
            if (password.Length >= 4)
            {
                player.moveTrue();
                SafeGroup.anchoredPosition = Vector3.down * 1000;
                if (password == "7942")
                {
                    isOpen = true;
                    StartCoroutine(Success());
                    StartCoroutine(OpenSafe());
                }
                else
                {
                    password = "";
                    StartCoroutine(Fail());
                }
            }
        }
    }

    IEnumerator Success()
    {
        player.accessText.text = "금고 문이 열립니다.";
        player.accessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        player.accessText.gameObject.SetActive(false);
    }

    IEnumerator Fail()
    {
        player.accessText.color = Color.red;
        player.accessText.text = "비밀 번호가 틀렸습니다.";
        player.accessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        player.accessText.color = Color.white;
        player.accessText.gameObject.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator OpenSafe()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 80; i++)
        {
            yield return new WaitForSeconds(0.001f);
            SafeHandle.transform.Rotate(0, 0, 2);
        }
        audioSource.clip = unLockSound;
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 90; i++)
        {
            yield return new WaitForSeconds(0.005f);
            SafeDoor.transform.Rotate(0, -1, 0);
        }
        CellarKey.GetComponent<BoxCollider>().enabled=true;
        yield return new WaitForSeconds(0.5f);
        audioSource.enabled = false;

    }

    public void Input1()
    {
        audioSource.Play();
        password += 1;
    }
    public void Input2()
    {
        audioSource.Play();
        password += 2;
    }
    public void Input3()
    {
        audioSource.Play();
        password += 3;
    }
    public void Input4()
    {
        audioSource.Play();
        password += 4;
    }
    public void Input5()
    {
        audioSource.Play();
        password += 5;
    }
    public void Input6()
    {
        audioSource.Play();
        password += 6;
    }
    public void Input7()
    {
        audioSource.Play();
        password += 7;
    }
    public void Input8()
    {
        audioSource.Play();
        password += 8;
    }
    public void Input9()
    {
        audioSource.Play();
        password += 9;
    }
}
