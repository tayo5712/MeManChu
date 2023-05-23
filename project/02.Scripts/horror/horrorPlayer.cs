using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;

public class horrorPlayer : MonoBehaviour
{
    public GameObject horrorManager;
    public HorrorManager horror;
    int Health;
    public bool eDown;
    bool hasFlashLight;
    public bool hasGarretKey;
    public bool hasCellarKey;
    public bool hasEntranceKey;
    public bool hasPrisonKey;
    public bool isDead;
    GameObject nearObject;

    public GameObject HorrorCanvas;

    public GameObject GamePanel;
    public GameObject TutorialPanel;

    public TMP_Text accessText;
    public TMP_Text alertText;

    public RectTransform MissionGroup;
    public TMP_Text MissionTitle;
    public TMP_Text MissionContent;

    public PlayerInput playerInput;
    public StarterAssetsInputs assetsInputs;
    Animator anim;

    void Awake()
    {
        Health = 3;
        horrorManager = GameObject.FindWithTag("HorrorManager");
        HorrorCanvas = GameObject.FindWithTag("HorrorCanvas");
        horror = horrorManager.GetComponent<HorrorManager>();
        anim = transform.GetComponent<Animator>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        assetsInputs = gameObject.GetComponent<StarterAssetsInputs>();

        GamePanel = HorrorCanvas.transform.Find("GamePanel").gameObject;
        TutorialPanel = HorrorCanvas.transform.Find("TutorialPanel").gameObject;

        accessText = HorrorCanvas.transform.Find("GamePanel/AccessText").gameObject.GetComponent<TMP_Text>();
        alertText = HorrorCanvas.transform.Find("GamePanel/AlertText").gameObject.GetComponent<TMP_Text>();

        MissionGroup = HorrorCanvas.transform.Find("GamePanel/MissionGroup").gameObject.GetComponent<RectTransform>();
        MissionTitle = HorrorCanvas.transform.Find("GamePanel/MissionGroup/MissionTitle").gameObject.GetComponent<TMP_Text>();
        MissionContent = HorrorCanvas.transform.Find("GamePanel/MissionGroup/MissionContent").gameObject.GetComponent<TMP_Text>();
    }
    void Start()
    {
        moveFalse();
        TutorialPanel.SetActive(true);
        horror.HorrorPlayer = this;
    }

    public void StartMissionOther(string title, string content)
    {
        StartCoroutine(StartMission(title, content));
    }
    public IEnumerator StartMission(string title, string content)
    {
        MissionTitle.text = title;
        MissionContent.text = content;
        MissionGroup.anchoredPosition = Vector3.zero + Vector3.up * 50;
        yield return new WaitForSeconds(3f);
        MissionGroup.anchoredPosition = Vector3.down * 1000;
    }   


    void Update()
    {
        GetInput();
        Interaction();
    }

    void GetInput()
    {
        eDown = Input.GetKey(KeyCode.E);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MeleeArea" && !isDead)
        {
            OnDamage();
        }
        if (other.tag == "HorrorEscape")
        {
            moveFalse();
            horror.GameFinish();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "FlashLight")
        {
            nearObject = other.gameObject;
            accessText.text = "'E'≈∞∏¶ ¥≠∑Øº≠ º’¿¸µÓ¿ª »πµÊ«œººø‰.";
            accessText.gameObject.SetActive(true);
        }
        else if (other.tag == "GarretKey")
        {
            nearObject = other.gameObject;
            accessText.text = "'E'≈∞∏¶ ¥≠∑Øº≠ ¥Ÿ∂ÙπÊ ø≠ºË∏¶ »πµÊ«œººø‰.";
            accessText.gameObject.SetActive(true);
        }
        else if (other.tag == "CellarKey")
        {
            nearObject = other.gameObject;
            accessText.text = "'E'≈∞∏¶ ¥≠∑Øº≠ ¡ˆ«œΩ« ø≠ºË∏¶ »πµÊ«œººø‰.";
            accessText.gameObject.SetActive(true);
        }
        else if (other.tag == "PrisonKey")
        {
            nearObject = other.gameObject;
            accessText.text = "'E'≈∞∏¶ ¥≠∑Øº≠ ∞®ø¡ ø≠ºË∏¶ »πµÊ«œººø‰.";
            accessText.gameObject.SetActive(true);
        }
        else if (other.tag == "EntranceKey")
        {
            nearObject = other.gameObject;
            accessText.text = "'E'≈∞∏¶ ¥≠∑Øº≠ «ˆ∞¸ ø≠ºË∏¶ »πµÊ«œººø‰.";
            accessText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "FlashLight" || other.tag == "GarretKey" || other.tag == "CellarKey" || other.tag == "EntranceKey" || other.tag == "PrisonKey" || other.tag == "Door")
        {

            nearObject = null;
        }
        accessText.gameObject.SetActive(false);
    }

    void Interaction()
    {
        if (eDown && nearObject != null)
        {
            horrorManager.GetComponent<AudioSource>().Play();
            if (nearObject.tag == "FlashLight")
            {
                accessText.gameObject.SetActive(false);
                hasFlashLight = true;
                Destroy(nearObject);
                transform.Find(
                    "rig/root/DEF-spine/DEF-spine.001/DEF-spine.002/DEF-spine.003/DEF-shoulder.R/DEF-upper_arm.R/DEF-forearm.R/DEF-hand.R/HandLight")
                    .gameObject.SetActive(true);
                transform.Find(
    "rig/Lighting")
    .gameObject.SetActive(true);
                StartCoroutine(ObtainMessage("º’¿¸µÓ¿ª »πµÊ«œºÃΩ¿¥œ¥Ÿ."));
            }
            else if (nearObject.tag == "GarretKey")
            {
                accessText.gameObject.SetActive(false);
                hasGarretKey = true;
                Destroy(nearObject);
                StartCoroutine(ObtainMessage("¥Ÿ∂ÙπÊ ø≠ºË∏¶ »πµÊ«œºÃΩ¿¥œ¥Ÿ."));
            }
            else if (nearObject.tag == "CellarKey")
            {
                accessText.gameObject.SetActive(false);
                hasCellarKey = true;
                Destroy(nearObject);
                StartCoroutine(ObtainMessage("¡ˆ«œΩ« ø≠ºË∏¶ »πµÊ«œºÃΩ¿¥œ¥Ÿ."));
            }
            else if (nearObject.tag == "PrisonKey")
            {
                accessText.gameObject.SetActive(false);
                hasPrisonKey = true;
                Destroy(nearObject);
                StartCoroutine(ObtainMessage("∞®ø¡ ø≠ºË∏¶ »πµÊ«œºÃΩ¿¥œ¥Ÿ."));
            }
            else if (nearObject.tag == "EntranceKey")
            {
                accessText.gameObject.SetActive(false);
                hasEntranceKey = true;
                Destroy(nearObject);
                StartCoroutine(ObtainMessage("«ˆ∞¸ ø≠ºË∏¶ »πµÊ«œºÃΩ¿¥œ¥Ÿ."));
            }
        }
    }

    public void ObtainMessageOther(string message)
    {
        StartCoroutine(ObtainMessage(message));
    }

    IEnumerator ObtainMessage(string message)
    {
        alertText.text = message;
        alertText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        alertText.gameObject.SetActive(false);
    }
    public void OnDamage()
    {
        if (Health > 0)
        {
            Health--;
            horror.myHelath(Health);
        }
        if (Health <= 0)
        {
            isDead = true;
            moveFalse();
            anim.SetTrigger("doDie");
            horror.GameOver();
        }
    }

    public void moveTrue()
    {
        playerInput.enabled = true;
        assetsInputs.cursorLocked = true;
        assetsInputs.cursorInputForLook = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void moveFalse()
    {
        playerInput.enabled = false;
        assetsInputs.cursorLocked = false;
        assetsInputs.cursorInputForLook = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void GameStart()
    {
        StartCoroutine(StartMission("Mission1", "º’¿¸µÓ¿ª √£∞Ì\n\n¥Ÿ∂ÙπÊ¿ª\n∫¸¡Æ≥™∞°∂Û."));
        moveTrue();
    }
}
