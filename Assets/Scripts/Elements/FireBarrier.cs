using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrier : MonoBehaviour
{
    private Animator animator;
    private Animator enemy_animator;
    [SerializeField]
    private GameObject Flamethrower;
    [SerializeField]
    private GameObject FireFieldRed;
    [SerializeField]
    private GameObject WindBall;
    [SerializeField]
    private GameObject AirTrail;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject punchEffect;
    [SerializeField]
    private GameObject CongratsText;
    
    void Awake()
    {        
        animator = GetComponent<Animator>();
        enemy_animator = GameObject.FindWithTag("Enemy").GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Enemy" && this.tag == "FireElement")
        {
            Mover.moverInstance.axis.z = 0;
            animator.SetBool("Fire", true);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
          
            StartCoroutine(StayForFire());
            punchEffect.SetActive(false);
            CongratsText.SetActive(true);
               
           
        }
        else if(col.gameObject.tag == "Enemy" && this.tag != "FireElement")
        {
            Mover.moverInstance.axis.z = 0;         
            WindBall.SetActive(false);
            AirTrail.SetActive(false);
            animator.SetBool("OnBall", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            enemy_animator.SetBool("Punch",true);
            StartCoroutine(PunchWait());
            
            
        }
    }
    public IEnumerator StayForFire()
    {
        FindObjectOfType<ButtonDetector>().TurnOffButtons();
        yield return new WaitForSeconds(1.1f);
        Flamethrower.SetActive(true);
        enemy_animator.SetBool("Punch", false);
        enemy_animator.SetBool("Death", true);
        AudioController.audioInstance.FireSound();
        
        yield return new WaitForSeconds(0.2f);
        FireFieldRed.SetActive(true);
        enemy.gameObject.tag = "EnemyDeath";
        punchEffect.SetActive(false);

        yield return new WaitForSeconds(1.3f);
        FindObjectOfType<ButtonDetector>().TurnOffButtonFire();
        Flamethrower.SetActive(false);
        Mover.moverInstance.axis = new Vector3(0,0,3f);
        animator.SetBool("Fire", false);
        animator.SetBool("Run", true);
        Destroy(FireFieldRed,4);
        Destroy(enemy,4);
    }

    public IEnumerator PunchWait()
    {
        yield return new WaitForSeconds(1.1f);
        punchEffect.SetActive(true);
    }
   
}
