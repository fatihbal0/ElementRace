using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject gameOver;
     public GameObject elements;
    
    
    private void OnTriggerEnter(Collider col)
    {
     
        
            gameOver.SetActive(true); 
            elements.SetActive(false); 
            Time.timeScale = 0;  
            AudioController.audioInstance.LoseSound();
        
    }
   
}
