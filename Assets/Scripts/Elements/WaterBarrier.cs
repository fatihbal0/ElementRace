using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterBarrier : MonoBehaviour
{
    
    [SerializeField]
    private GameObject WindBall;
    private Animator animator;
    Rigidbody rb;
    private IceTrail iceTrail;
     [SerializeField]
    private GameObject FireTrail;
    [SerializeField]
    private GameObject WaterTrail;
    [SerializeField]
    private GameObject AirTrail;
    [SerializeField]
    private GameObject EarthTrail;
    BoxCollider DeepWaterCollider;
    bool waterBarrierFinish;
    

    void Awake()
    {
        animator = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody>();
        iceTrail = GetComponent<IceTrail>();
        DeepWaterCollider = GameObject.FindWithTag("DeepWater").GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "WaterBarrier" && this.tag == "WaterElement")
        {
            animator.SetBool("Water", true);
            animator.SetBool("Run", false);
            iceTrail.CallInvoke();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;            
            Mover.moverInstance.axis = new Vector3(0,0,10f);
            Destroy(col.gameObject);
            AudioController.audioInstance.WaterSound();
        }
        else if(col.gameObject.tag == "WaterBarrier" && this.tag != "WaterElement")
        {
            WindBall.SetActive(false);
            AirTrail.SetActive(false);
            animator.SetBool("OnBall", false);
            animator.SetBool("Run", false);
            animator.SetBool("Swim", true);

            FireTrail.SetActive(false);
            EarthTrail.SetActive(false);
            AirTrail.SetActive(false);  
            Mover.moverInstance.axis = new Vector3(0,0,5f);
            Destroy(col.gameObject);
        }
        
       if(col.gameObject.tag == "WaterBarrierFinish" && this.tag != "AirElement")
        { 

            waterBarrierFinish = true;
            animator.SetBool("Water", false);
            animator.SetBool("Swim", false);
            animator.SetBool("Run", true);
            iceTrail.InvokeCloser();
            transform.DOMoveY(1f,0.1f);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
            DeepWaterCollider.enabled=false;
            Destroy(col.gameObject);
            if(this.tag == "EarthElement")
            EarthTrail.SetActive(true);
            if(this.tag == "FireElement")
            FireTrail.SetActive(true);
        }
        
        if(col.gameObject.tag == "WaterBarrierFinish" && this.tag == "AirElement")
        {           

            waterBarrierFinish = true;
            animator.SetBool("Water", false);
            animator.SetBool("Swim", false);
            animator.SetBool("OnBall", true);
            iceTrail.InvokeCloser();
            transform.DOMoveY(4.1f,0.1f);
            WindBall.SetActive(true);
            AirTrail.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
           DeepWaterCollider.enabled=false;
           Destroy(col.gameObject);
        }

        
       
       if(col.gameObject.tag == "SpeedAdjustment" && this.tag == "AirElement") 
        {   
            Mover.moverInstance.axis = new Vector3(0,0,10f); 
        }    
        else if(col.gameObject.tag == "SpeedAdjustment" && this.tag != "AirElement")
        {            
            Mover.moverInstance.axis = new Vector3(0,0,3f);        
        }

    }

    private void OnCollisionEnter(Collision coll) 
    {
        if(coll.gameObject.tag == "DeepWater" && this.tag == "WaterElement")
        {
            if(!waterBarrierFinish)
            {
                AudioController.audioInstance.WaterSound();
                Mover.moverInstance.axis = new Vector3(0,0,10f);            
                animator.SetBool("Run", false); 
                animator.SetBool("Swim", false);
                animator.SetBool("Water", true);
                transform.DOMoveY(1f,0.1f);
                iceTrail.CallInvoke();
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ 
                | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            
            }
            
        }
        else if(coll.gameObject.tag == "DeepWater" && this.tag != "WaterElement")
        {
            if(!waterBarrierFinish)
            {
                Mover.moverInstance.axis = new Vector3(0,0,3f);
                animator.SetBool("Water", false);
                animator.SetBool("Run", false);   
                animator.SetBool("Swim", true); 
                iceTrail.InvokeCloser();   
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
                AirTrail.SetActive(false);
                FireTrail.SetActive(false);
                EarthTrail.SetActive(false);
            }
        }
        
        
        
    }

}




