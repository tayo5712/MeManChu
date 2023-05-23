using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class FireCallback : MonoBehaviour
{

    private ThirdPersonController player;
    private CharacterController user;

    ParticleSystem ps;

    public Image fireDamage;

    private float fireHp = 2.0f;
    private bool fireLevel = true;

    //List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    //List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    
    void OnEnable()
    {
/*        user = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player").GetComponent<ThirdPersonController>();
        ps = GetComponent<ParticleSystem>();
        ps.trigger.AddCollider(user);*/
        
    }
    private void Update()
    {
/*        user = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player").GetComponent<ThirdPersonController>();
        ps = GetComponent<ParticleSystem>();
        ps.trigger.AddCollider(user);*/
        if (fireHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "user")
        {
            //Debug.Log(other.name);
            other.GetComponentInParent<ThirdPersonController>().currentHealth -=  3;
            StopCoroutine(ShowFireDamage());
            StartCoroutine(ShowFireDamage());
        }

        if (other.tag == "AntiFire")
        {
  
            Debug.Log(other.name);
            if (fireLevel)
            {
               StartCoroutine(FireHpDamage());
            }
        }

    }

/*    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        if (numEnter > 0)
        {
            StartCoroutine(ShowFireDamage());
            player.currentHealth -= 1;
        }
    }*/

    IEnumerator ShowFireDamage()
    {
        fireDamage.color = new Color(0.5f, 0.5f, 0.5f, 1);
        yield return new WaitForSeconds(1.1f);
        fireDamage.color = Color.clear;
    }

    IEnumerator FireHpDamage()
    {
        fireLevel = false;
        yield return new WaitForSeconds(1.1f);
        Debug.Log("1µ¥¹ÌÁö");
        fireHp -= 1;
        fireLevel = true;
    }
}

