using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherIceTrail : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabRock;
    [SerializeField]
    private GameObject leftleg;
    [SerializeField]
    private GameObject rightleg;
    Rigidbody rb;
    Vector3 offset = new Vector3(0f,0f,-1f);
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }



    void SpawnIce()
    {
        Instantiate(prefabRock, leftleg.transform.position + offset, Quaternion.identity);
        Instantiate(prefabRock, rightleg.transform.position + offset, Quaternion.identity);

    }

    public void CallInvoke()
    {
        InvokeRepeating("SpawnIce", 0.1f, 0.2f);
    }
    public void InvokeCloser()
    {
        CancelInvoke("SpawnIce");
    }
}
