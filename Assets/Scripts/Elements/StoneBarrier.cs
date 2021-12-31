using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StoneBarrier : MonoBehaviour
{
   private Animator animator;
   
    [SerializeField]
    private GameObject WindBall;
    [SerializeField]
    private GameObject AirTrail;
    [SerializeField]
    private GameObject CongratsText;
 
    private void Awake() 
    {       
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Rock" && this.tag == "EarthElement")
        {
           Mover.moverInstance.axis.z = 0;
           animator.SetBool("Earth", true);
           animator.SetBool("Run", false);
           animator.SetBool("Idle", false); 
           
           FindObjectOfType<RockWall>().StartRockExplosion();

           StartCoroutine(StayForEarth());  
           CongratsText.SetActive(true);       
           
        }
        else if(col.gameObject.tag == "Rock" && this.tag != "EarthElement")
        {
            Mover.moverInstance.axis.z = 0;
            WindBall.SetActive(false);
            AirTrail.SetActive(false);
            animator.SetBool("OnBall", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);                    
        }
        
    }
    public IEnumerator StayForEarth()
    {
        FindObjectOfType<ButtonDetector>().TurnOffButtons();
        yield return new WaitForSeconds(1.5f);
        AudioController.audioInstance.EarthSound();
        yield return new WaitForSeconds(1.5f);
        
        Mover.moverInstance.axis = new Vector3(0,0,3f);
        animator.SetBool("Earth", false);
        animator.SetBool("Run", true);
        FindObjectOfType<ButtonDetector>().TurnOffButtonEarth();
    }

}
