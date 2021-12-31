using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AirBarrier : MonoBehaviour
{
   [SerializeField]
    private GameObject AirKite;
    [SerializeField]
    private GameObject WindBall;
    Rigidbody rb;    
    Animator animator;
    [SerializeField]
    private GameObject CongratsText;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "AirBarrierStart" && this.tag == "AirElement")
        {
            transform.DOMoveY(5f,0.7f);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            
            animator.SetBool("Air", true);
            animator.SetBool("OnBall", false);
            animator.SetBool("Run", false);
            AirKite.SetActive(true);
            WindBall.SetActive(false);
            CongratsText.SetActive(true);
            AudioController.audioInstance.AirBackgroundSound();
        }
        
        if(col.gameObject.tag == "AirBarrierFinish" && this.tag != "AirElement")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX 
            | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ 
            | RigidbodyConstraints.FreezePositionX;
            animator.SetBool("Air", false);
            animator.SetBool("Run", true);
            AirKite.SetActive(false);
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "AirBarrierFinish" && this.tag == "AirElement")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY 
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
            animator.SetBool("Air", false);
            animator.SetBool("OnBall", true);
            AirKite.SetActive(false);
            WindBall.SetActive(true);
            Destroy(col.gameObject);
            AudioController.audioInstance.AirBackgroundStop();
            
        }
    }
    


    
}
