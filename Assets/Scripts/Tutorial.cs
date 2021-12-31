using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{    
    [SerializeField]
    private GameObject _TransformFire;
    [SerializeField]
    private GameObject _TransformWater;
    [SerializeField]
    private GameObject _TransformEarth;
    [SerializeField]
    private GameObject _TransformAir;
    [SerializeField]
    private GameObject _TransformAirBall;
    ButtonDetector buttonDetector;
    bool _isFire, _isEarth, _isWater, _isAir, _isAirBall;

    void Start() {
        {
            buttonDetector  = GetComponent<ButtonDetector>();
        }
    }

        private void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "TutorialFireBarrier")
            {
                _isFire = true;
                Destroy(col.gameObject);
                TransformFire();
                buttonDetector.FireInteractable();
            }

            else if(col.gameObject.tag == "TutorialWaterBarrier")
            {
                _isWater = true;
                Destroy(col.gameObject);
                TransformWater();
                buttonDetector.WaterInteractable();
            }

            else if(col.gameObject.tag == "TutorialEarthBarrier")
            {
                _isEarth = true;
                Destroy(col.gameObject);
                TransformEarth();
                buttonDetector.EarthInteractable();
            }

            else if(col.gameObject.tag == "TutorialAirBarrier")
            {
                _isAir = true;
                Destroy(col.gameObject);
                TransformAir();
                buttonDetector.AirInteractable();
            }
             else if(col.gameObject.tag == "TutorialAirBallBarrier")
            {
                _isAirBall = true;
                Destroy(col.gameObject);
                TransformAirBall();
                buttonDetector.AirInteractable();
            }
        }


    public void TransformFire()
    {
        Time.timeScale = 0f;
        _TransformFire.SetActive(true);
    }

    public void TransformWater()
    {
        Time.timeScale = 0f;
        _TransformWater.SetActive(true);
    }

    public void TransformEarth()
    {
        Time.timeScale = 0f;
        _TransformEarth.SetActive(true);
    }

    public void TransformAir()
    {
        Time.timeScale = 0f;
        _TransformAir.SetActive(true);
    }

    public void TransformAirBall()
    {
        Time.timeScale = 0f;
        _TransformAirBall.SetActive(true);
    }

    public void FireTimeScale()
    {
        if(_isFire)
        {
        _TransformFire.SetActive(false);        
        Time.timeScale = 1f;
        _isFire = false;
        }
    }

    public void WaterTimeScale()
    {
        if(_isWater)
        {
        _TransformWater.SetActive(false);        
        Time.timeScale = 1f;
        _isWater = false;
        }
    }

    public void EarthTimeScale()
    {
        if(_isEarth)
        {
        _TransformEarth.SetActive(false);        
        Time.timeScale = 1f;
        _isEarth = false;
        }
    }

    public void AirTimeScale()
    {
        if(_isAir)
        {
        _TransformAir.SetActive(false);        
        Time.timeScale = 1f;
        _isAir = false;
        }
    }

    public void AirTimeScaleBall()
    {
        if(_isAirBall)
        {
        _TransformAirBall.SetActive(false);        
        Time.timeScale = 1f;
        _isAirBall = false;
        }
    }
}
