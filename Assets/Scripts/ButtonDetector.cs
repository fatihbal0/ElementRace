using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonDetector : MonoBehaviour
{
    [SerializeField]
    GameObject[] ImageList;
    [SerializeField]
    private Transform CameraStack;
    [SerializeField]
    private GameObject WindBall;
    [SerializeField]
    private Button FireButton;
    [SerializeField]
    private Button WaterButton;
    [SerializeField]
    private Button EarthButton;
    [SerializeField]
    private Button AirButton;
    [SerializeField]
    private GameObject AirKite;
    private BoxCollider boxCollider;
    private bool jump;
    private bool isAnimation;

    
    Rigidbody rb;
    private Animator animator;
    private Animator enemy_animator;
    bool IFire, IWater, IEarth, IAir;


    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        enemy_animator = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        jump = true;    
        
    }

    public void FireSelected()
    {
        AudioController.audioInstance.ElementChange();
        Mover.moverInstance.axis = new Vector3(0f,0f,3.0f);
        ImageList[0].SetActive(true);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(false);
        gameObject.tag = "FireElement";        
        IFire = true; IWater = false; IEarth = false; IAir = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
        | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ 
        | RigidbodyConstraints.FreezePositionX;
        boxCollider.enabled=false;
        boxCollider.enabled=true;
        StartCoroutine(InteractableWait());           
        WindBall.SetActive(false);
        AirKite.SetActive(false);
        animator.SetBool("OnBall", false);
        animator.SetBool("Air", false);
        animator.SetBool("Run", true);
        enemy_animator.Play("EnemyIdle");
        
        
    }
    public void WaterSelected()
    {
        AudioController.audioInstance.ElementChange();
        Mover.moverInstance.axis = new Vector3(0f,0f,3.0f);
        gameObject.tag = "WaterElement";        
        IWater = true; IFire = false; IEarth = false; IAir = false;
        boxCollider.enabled=false;
        boxCollider.enabled=true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
        | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ 
        | RigidbodyConstraints.FreezePositionX;
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(true);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(false);
        StartCoroutine(InteractableWait());
        WindBall.SetActive(false);
        AirKite.SetActive(false);
        animator.SetBool("OnBall", false);
        animator.SetBool("Air", false);
        animator.SetBool("Run", true);

        
    }
    
    public void EarthSelected()
    {
        AudioController.audioInstance.ElementChange();
        Mover.moverInstance.axis = new Vector3(0f,0f,3.0f);
        gameObject.tag = "EarthElement";
        IEarth = true; IWater = false; IFire = false; IAir = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
        | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ 
        | RigidbodyConstraints.FreezePositionX;       
        boxCollider.enabled=false;
        boxCollider.enabled=true;
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(true);
        ImageList[3].SetActive(false);
        StartCoroutine(InteractableWait());
        WindBall.SetActive(false);
        AirKite.SetActive(false);
        animator.SetBool("Water", false);
        animator.SetBool("OnBall", false);
        animator.SetBool("Air", false);
        animator.SetBool("Run", true);
        
        
    }
    public void AirSelected()
    {
        Debug.Log("air");
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(true);
        Mover.moverInstance.axis = new Vector3(0f,0f,10.0f);
        gameObject.tag = "AirElement";
        IAir = true; IWater = false; IEarth = false; IFire = false;
        boxCollider.enabled=false;
        boxCollider.enabled=true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
        | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ 
        | RigidbodyConstraints.FreezePositionX;        
        AudioController.audioInstance.AirSound();
        AudioController.audioInstance.ElementChange();
        StartCoroutine(InteractableWait());
        
        
        if(jump)
        {
            transform.DOMoveY(3.1f,0.01f);
            animator.SetBool("OnBall", true);
            animator.SetBool("Run", false);
            animator.Play("OnBall");
            WindBall.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if((other.gameObject.CompareTag("Enemy") && this.tag == "FireElement") || (other.gameObject.CompareTag("Rock") && this.tag == "EarthElement"))
        {
            isAnimation=true;
        }

        if(other.gameObject.tag == "WaterBarrier")
        {
            jump = false;
        }

        if(other.gameObject.tag == "WaterBarrierFinish")
        {
            jump = true;
        }
        
    }

    public IEnumerator InteractableWait()
{
        TurnOffButtons();
        yield return new WaitForSeconds(1f);
        if(!isAnimation)
        {
        FireButton.interactable= !IFire;
        WaterButton.interactable= !IWater;
        EarthButton.interactable= !IEarth;
        AirButton.interactable= !IAir;
        }
}

    public void TurnOffButtons()
    {
        FireButton.interactable= false;
        WaterButton.interactable= false;
        EarthButton.interactable= false;
        AirButton.interactable= false;
    }

    public void TurnOffButtonFire()
    {
        FireButton.interactable= false;
        WaterButton.interactable= true;
        EarthButton.interactable= true;
        AirButton.interactable= true;
        isAnimation=false;
    }

    public void TurnOffButtonEarth()
    {
        FireButton.interactable= true;
        WaterButton.interactable= true;
        EarthButton.interactable= false;
        AirButton.interactable= true;
        isAnimation=false;
    }

    public void FireInteractable()
    {
        FireButton.interactable= true;
        WaterButton.interactable= false;
        EarthButton.interactable= false;
        AirButton.interactable= false;
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(false);
    }

    public void WaterInteractable()
    {
        FireButton.interactable= false;
        WaterButton.interactable= true;
        EarthButton.interactable= false;
        AirButton.interactable= false;
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(false);
    }

    public void EarthInteractable()
    {
        FireButton.interactable= false;
        WaterButton.interactable= false;
        EarthButton.interactable= true;
        AirButton.interactable= false;
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(false);
    }

    public void AirInteractable()
    {
        FireButton.interactable= false;
        WaterButton.interactable= false;
        EarthButton.interactable= false;
        AirButton.interactable= true;
        ImageList[0].SetActive(false);
        ImageList[1].SetActive(false);
        ImageList[2].SetActive(false);
        ImageList[3].SetActive(false);
    }

}