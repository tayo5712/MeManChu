using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public enum Type { Melee, Range };
    public Type type;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    
    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
        if (type == Type.Range)
        {   
            meleeArea.enabled= true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            meleeArea.enabled = false;
        }
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(1f);
        meleeArea.enabled = false;
        trailEffect.enabled = false;
    }

/*    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crush")
        {
            Debug.Log("crush");
        }
    }*/
}
