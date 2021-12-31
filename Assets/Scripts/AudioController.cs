using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{  
    [SerializeField]
    AudioClip buttonClickSound;
    [SerializeField]
    AudioClip loseSound;
    [SerializeField]
    AudioClip retryButtonSound;
    [SerializeField]
    AudioClip winSound;
    [SerializeField]
    AudioClip fireSound;
    [SerializeField]
    AudioClip earthSound;
    [SerializeField]
    AudioClip waterSound;
    [SerializeField]
    AudioClip airSound;
    [SerializeField]
    AudioClip airBackgroundSound;
    [SerializeField]
    AudioClip punchSound;
    [SerializeField]
    AudioClip elementChange;
    AudioSource audioSource;

    public static AudioController audioInstance;

    private void Awake() 
    {
        if(audioInstance == null)
        {
            audioInstance = this;
        }
        else if(audioInstance != null)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound, 0.5f);
    }

    public void LoseSound()
    {
       audioSource.PlayOneShot(loseSound, 0.8f);
    }

    public void RetryButtonSound()
    {
        audioSource.PlayOneShot(retryButtonSound, 0.5f);
    }
    public void WinSound()
    {
       audioSource.PlayOneShot(winSound, 0.3f);
    }

    public void FireSound()
    {
       audioSource.PlayOneShot(fireSound, 0.15f);
    }

    public void EarthSound()
    {
       audioSource.PlayOneShot(earthSound, 0.2f);
    }

    public void WaterSound()
    {
       audioSource.PlayOneShot(waterSound, 0.07f);
    }
    
    public void AirSound()
    {
       audioSource.PlayOneShot(airSound, 0.05f);
    }
    
    public void AirBackgroundSound()
    {
       audioSource.PlayOneShot(airBackgroundSound, 0.5f);
    }

     public void AirBackgroundStop()
    {
       audioSource.Stop();
    }
    
    public void PunchSound()
    {
       audioSource.PlayOneShot(punchSound, 0.5f);
    }

    public void ElementChange()
    {
       audioSource.PlayOneShot(elementChange, 0.7f);
    }
}

    

