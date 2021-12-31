using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject levelFailed;
  public GameObject elements;
  public GameObject startGame;
  private OtherRacerAI otherMover;
  private Mover playerMover;

  private Animator playerAnimator;
  private Animator otherAnimator;

  private void Awake()
    {
      otherAnimator = GameObject.FindWithTag("OtherRacer").GetComponent<Animator>();
      playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
      otherMover = GameObject.FindWithTag("OtherRacer").GetComponent<OtherRacerAI>();
    }

  public void StartGame()
  {
    Time.timeScale = 1f;
    AudioController.audioInstance.ButtonClickSound();
    elements.SetActive(true);
    startGame.SetActive(false);
    playerAnimator.Play("Run");
    otherAnimator.Play("Run");
    Mover.moverInstance.axis.z=3;
    otherMover.enabled = true;

  }
 
}