using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OtherRacerAI : MonoBehaviour
{
    [SerializeField]
    private GameObject AirKite;
    [SerializeField]
    private GameObject WindBall;
    [SerializeField]
    private GameObject Flamethrower;
    private Animator anim_otherRacer;
    private Animator enemy_animator;
    [SerializeField]
    private GameObject enemy;
    private Rigidbody rb_otherRacer;
    [SerializeField]
    private GameObject FireFieldRed;
    private OtherIceTrail otherIceTrail;
    public Vector3 axis = new Vector3(0,0,10);

    void Start()
    {
        anim_otherRacer = GetComponent<Animator>();
        enemy_animator = GameObject.FindWithTag("OtherEnemy").GetComponent<Animator>();
        rb_otherRacer = GetComponent<Rigidbody>();
        otherIceTrail = GetComponent<OtherIceTrail>();

        StartCoroutine(RunOnBall());

    }
    void Update()
    {
        transform.position += axis * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col) 
    {
        /* HAVA SORGUSU */
        if(col.gameObject.tag == "AirBarrierStart" ) 
        {
            axis = new Vector3(0,0,10f);
            anim_otherRacer.SetBool("Air", true);
            anim_otherRacer.SetBool("OnBall", false);
            anim_otherRacer.SetBool("Run", false);

            rb_otherRacer.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            transform.DOMoveY(5f,0.7f);

            AirKite.SetActive(true);
            WindBall.SetActive(false); 
        }
        else if(col.gameObject.tag == "OtherAirBarrierFinish")
        {
            anim_otherRacer.SetBool("Air", false);
            anim_otherRacer.SetBool("OnBall", true);

            rb_otherRacer.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;

            AirKite.SetActive(false);
            WindBall.SetActive(true);
        }
        /* TOPRAK SORGUSU */

        else if(col.gameObject.tag == "EnemyRock")
        {
            StartCoroutine(EarthEnter());
        }
        

        /* ATEŞ SORGUSU */

        else if(col.gameObject.tag == "OtherEnemy")
        {
            StartCoroutine(FireEnter());

        }

        /* SU SORGUSU */
        else if(col.gameObject.tag == "WindBallCloser")
        {
            UnequipAll();
            anim_otherRacer.SetBool("Run",true);
            anim_otherRacer.SetBool("OnBall",false);
            axis = new Vector3(0,0,5f);

        }
        else if(col.gameObject.tag == "OtherWaterBarrierStart")
        {
            axis = new Vector3(0,0,10f);
            anim_otherRacer.SetBool("Water", true);
            anim_otherRacer.SetBool("Run", false);
            anim_otherRacer.SetBool("OnBall", false);
            otherIceTrail.CallInvoke();
            rb_otherRacer.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;

        }
        else if(col.gameObject.tag == "OtherWaterBarrierFinish")
        {
            anim_otherRacer.SetBool("Water", false);
            anim_otherRacer.SetBool("Run", true);
            otherIceTrail.InvokeCloser();
            rb_otherRacer.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
            otherIceTrail.enabled = false;
            axis = new Vector3(0,0,3f);
            StartCoroutine(RunOnBall());
        }

    }


    

    public IEnumerator RunOnBall() 
    {
        yield return new WaitForSeconds(Random.Range(1.5f , 2.5f));
        transform.DOMoveY(3f,0.01f);
        axis = new Vector3(0,0,10f);
        anim_otherRacer.SetBool("OnBall",true);
        anim_otherRacer.SetBool("Run", false);
        WindBall.SetActive(true);
        
    }

    public IEnumerator EarthEnter() 
    {
        axis.z = 0 ;

        UnequipAll();
        
        anim_otherRacer.SetBool("OnBall", false);
        anim_otherRacer.SetBool("Idle", true);
        yield return new WaitForSeconds(Random.Range(1f , 3f));

        anim_otherRacer.SetBool("Earth", true);
        anim_otherRacer.SetBool("Idle", false);
        GameObject.Find("EnemyRock").GetComponent<OtherRacerRock>().StartEnemyRockExplosion();
        yield return new WaitForSeconds(3f);

        

        anim_otherRacer.SetBool("Earth", false);
        anim_otherRacer.SetBool("Run", true);
        axis.z = 3;

        StartCoroutine(RunOnBall());
        
        
    }

    public IEnumerator FireEnter()
    {
        axis.z = 0;

        UnequipAll();

        anim_otherRacer.SetBool("OnBall", false);
        anim_otherRacer.SetBool("Idle", true);
        anim_otherRacer.SetBool("Run", false);
        enemy_animator.SetBool("Punch",true);
        yield return new WaitForSeconds(Random.Range(1f , 2f));
        anim_otherRacer.SetBool("Fire", true);
        anim_otherRacer.SetBool("Idle", false);
        yield return new WaitForSeconds(1.1f);
        Flamethrower.SetActive(true);
        enemy_animator.SetBool("Punch",false);
        
        yield return new WaitForSeconds(0.2f);
        enemy_animator.SetBool("Death", true);
        FireFieldRed.SetActive(true);
        enemy.tag = "EnemyDeath";

        yield return new WaitForSeconds(1.3f);
        
        Flamethrower.SetActive(false);
        axis.z = 3;
        anim_otherRacer.SetBool("Fire", false);
        anim_otherRacer.SetBool("Run", true);
        StartCoroutine(RunOnBall());
        
    }

    private void UnequipAll()
    {
        WindBall.SetActive(false);
        AirKite.SetActive(false);
        Flamethrower.SetActive(false);
    }

    




}
