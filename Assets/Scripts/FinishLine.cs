using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private GameObject WindBall;
    public GameObject levelComplete;
    public GameObject elements;
    public GameObject gameOver;
    [SerializeField]
    private GameObject player;
    public Animator animator;
    [SerializeField]
    private GameObject elementEffect;
    [SerializeField]
    private GameObject Confetti1;
    [SerializeField]
    private GameObject Confetti2;
    [SerializeField]
    private GameObject ConfettiShower;
    [SerializeField]
    private GameObject AirTrail;
    private OtherRacerAI otherMover;

    Vector3 offset = new Vector3(1f,1.5f,-1f);



    void Awake()
    {
        animator = player.GetComponent<Animator>(); 
    }
    void Start()
    {
        otherMover = GameObject.FindWithTag("OtherRacer").GetComponent<OtherRacerAI>();
    }

    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "WaterElement" || col.gameObject.tag == "FireElement" || col.gameObject.tag == "AirElement" || col.gameObject.tag == "EarthElement" )
        {
            Instantiate(elementEffect,transform.position + offset, Quaternion.identity);
            WindBall.SetActive(false);
            levelComplete.SetActive(true);
            elements.SetActive(false);
            FindObjectOfType<Mover>().enabled = false;
            animator.Play("WinDance");
            Confetti1.SetActive(true);
            Confetti2.SetActive(true);
            ConfettiShower.SetActive(true);
            AirTrail.SetActive(false);
            otherMover.enabled = false;
            AudioController.audioInstance.WinSound();
              
        }
        else if (col.gameObject.tag == "OtherRacer")
        {
            gameOver.SetActive(true);  
            Time.timeScale = 0;
            elements.SetActive(false);
        }
    }


}
