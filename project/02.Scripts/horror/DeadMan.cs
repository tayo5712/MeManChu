using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeadMan : MonoBehaviour
{
    public enum Type { WGhoul, BGhoul, Ring};
    public Type DeadType;
    public BoxCollider meleeArea;
    public GameObject DestinationA;
    public bool Aarrive;
    public GameObject DestinationB;
    public bool Barrive;
    public Transform target;
    public bool isChase;
    public bool isAttack;
    AudioSource audioSource;

    [SerializeField] float d_angle = 0f;
    [SerializeField] float d_distance = 0f;
    [SerializeField] float Find_Range = 0f;
    [SerializeField] float Find_Radius = 0f;
    [SerializeField] int ChaseTime = 0;
    [SerializeField] LayerMask playerLayerMask = 0;

    public Rigidbody rigid;
    public NavMeshAgent nav;
    public Animator anim;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        meleeArea = transform.Find("Melee").GetComponent<BoxCollider>();
        SetDestination();
    }

    void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        Sight();
        if (nav.enabled)
        {
            nav.isStopped = isAttack;
        }
    }
    void FixedUpdate()
    {
        FreezeVelocity();
        Targeting();
    }

    void Sight()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, d_distance, playerLayerMask);
        if (t_cols.Length > 0 && !isChase)
        {
            Transform t_player = t_cols[0].transform;
            Vector3 t_direction = (t_player.position - transform.position).normalized;
            float t_angle = Vector3.Angle(t_direction, transform.forward);

            if (t_angle < d_angle * 0.5f) 
            {
                RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, Find_Radius, transform.forward, Find_Range, LayerMask.GetMask("Player"));
                if (rayHits.Length > 0)
                {
                    StartCoroutine(ChasePlayer(rayHits[0].transform));
                }
            }
        }
    }

    IEnumerator ChasePlayer(Transform player)
    {
        transform.Find("SearchMark").gameObject.SetActive(true);
        isChase = true;
        for (int i = 0; i < ChaseTime; i++)
        {
            SetDestination(player.transform);
            yield return new WaitForSeconds(1f);
        }
        transform.Find("SearchMark").gameObject.SetActive(false);
        isChase = false;
        SetDestination();
    }

    void SetDestination(Transform destination)
    {
        audioSource.pitch = 1.5f;
        audioSource.volume = 0.4f;
        anim.SetBool("isWalk", true);
        if (destination.tag == "Player")
        {
            switch (DeadType)
            {
                case Type.WGhoul:
                    anim.speed = 2.5f;
                    nav.speed = 2.5f;
                    audioSource.pitch = 1.5f;
                    audioSource.volume = 0.2f;
                    break;
                case Type.BGhoul:
                    anim.speed = 3f;
                    nav.speed = 3f;
                    audioSource.pitch = 1.5f;
                    audioSource.volume = 0.2f;
                    break;
                case Type.Ring:
                    anim.speed = 5f;
                    nav.speed = 5f;
                    audioSource.pitch = 1.5f;
                    audioSource.volume = 0.4f;
                    break;
            }
            nav.SetDestination(destination.position);
        }
    }

    void SetDestination()
    {

        anim.SetBool("isWalk", true);
        switch (DeadType)
        {
            case Type.WGhoul:
                anim.speed = 1.5f;
                nav.speed = 1;
                audioSource.pitch = 1f;
                audioSource.volume = 0.1f;
                break;
            case Type.BGhoul:
                anim.speed = 0.4f;
                nav.speed = 0.5f;
                audioSource.pitch = 1f;
                audioSource.volume = 0.1f;
                break;
            case Type.Ring:
                anim.speed = 1f;
                nav.speed = 1;
                audioSource.pitch = 1f;
                audioSource.volume = 0.2f;
                break;
        }
        if (Aarrive && Barrive)
        {
            Aarrive = false;
            Barrive = false;
        }

        if (!Aarrive)
        {
            nav.SetDestination(DestinationA.transform.position);
        }
        else if (!Barrive)
        {
            nav.SetDestination(DestinationB.transform.position);
        }
    }

    void Targeting()
    {
        if (isChase)
        {
            // ShpereCat()의 반지름, 길이를 조절할 변수 선언
            float targetRadius = 0;
            float targetRange = 0;

            // switch문으로 각 타겟팅 수치를 정하기
            switch (DeadType)
            {
                case Type.WGhoul:
                    targetRadius = 1f;
                    targetRange = 0.5f;
                    break;
                case Type.BGhoul:
                    targetRadius = 1f;
                    targetRange = 0.5f;
                    break;
                case Type.Ring:
                    targetRadius = 1f;
                    targetRange = 0.5f;
                    break;
            }
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

            if (rayHits.Length > 0 && !isAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        isAttack = true;
        switch (DeadType)
        {
            case Type.WGhoul:
                anim.SetBool("isAttack", true);
                yield return new WaitForSeconds(0.5f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.3f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
            case Type.BGhoul:
                anim.SetBool("isAttack", true);
                yield return new WaitForSeconds(0.5f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.3f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
            case Type.Ring:
                anim.SetBool("isAttack", true);
                yield return new WaitForSeconds(0.5f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.3f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
        }
        isAttack = false;
        anim.SetBool("isAttack", false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestinationA" && !Aarrive)
        {
            Aarrive = true;
            SetDestination();
        }
        else if (other.tag == "DestinationB" && !Barrive)
        {
            Barrive = true;
            SetDestination();
        }
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }
}
