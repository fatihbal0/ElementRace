using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
   public Material fireMat;
   public Material airMat;
   public Material earthMat;
   public Material waterMat;

   [SerializeField]
    private GameObject FireTrail;
    [SerializeField]
    private GameObject WaterTrail;
    [SerializeField]
    private GameObject AirTrail;
    [SerializeField]
    private GameObject EarthTrail;
    [SerializeField]
    private GameObject elementEffect;
    Vector3 offset = new Vector3(2f,1.5f,0.5f);

    public void FireColour()
   {
      transform.GetComponent<SkinnedMeshRenderer>().material = fireMat;
      Instantiate(elementEffect,transform.position + offset, Quaternion.identity);
      FireTrail.SetActive(true);
      EarthTrail.SetActive(false);
      WaterTrail.SetActive(false);
      AirTrail.SetActive(false);    
   }

     public void AirColour()
   {
      transform.GetComponent<SkinnedMeshRenderer>().material = airMat;
      Instantiate(elementEffect, transform.position + offset, Quaternion.identity);
      AirTrail.SetActive(true);
      FireTrail.SetActive(false);
      EarthTrail.SetActive(false);
      WaterTrail.SetActive(false);
    
   }

     public void EarthColour()
   {
      transform.GetComponent<SkinnedMeshRenderer>().material = earthMat;
      Instantiate(elementEffect, transform.position+ offset, Quaternion.identity);
      EarthTrail.SetActive(true);
      FireTrail.SetActive(false);
      WaterTrail.SetActive(false);
      AirTrail.SetActive(false);
   }

     public void WaterColour()
   {
      transform.GetComponent<SkinnedMeshRenderer>().material = waterMat;
      Instantiate(elementEffect,transform.position+ offset, Quaternion.identity);
      WaterTrail.SetActive(true);
      FireTrail.SetActive(false);
      EarthTrail.SetActive(false);
      AirTrail.SetActive(false);
   }
 }
