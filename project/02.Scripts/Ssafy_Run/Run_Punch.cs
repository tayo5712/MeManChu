using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Run_Punch : MonoBehaviour
{
    Animator animator;
    private bool cool;
    private TextMeshProUGUI CoolDown;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cool = true;
       /* CoolDown = GameObject.Find("CoolDownt").GetComponent<TextMeshProUGUI>();*/
    }

    // Update is called once per frame
    void Update()
    {   
        Punch();
    }

    void Punch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Punch");
        }
        /*if (Input.GetMouseButtonDown(1) && cool == true)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
            
        }*/
    }
/*    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.01f);
        animator.SetTrigger("Swing");
        cool = false;
        CoolDown.text = "5";
        yield return new WaitForSeconds(1f);
        CoolDown.text = "4";
        yield return new WaitForSeconds(1f);
        CoolDown.text = "3";
        yield return new WaitForSeconds(1f);
        CoolDown.text = "2";
        yield return new WaitForSeconds(1f);
        CoolDown.text = "1";
        yield return new WaitForSeconds(1f);
        CoolDown.text = "";
        cool = true;

    }*/
}
