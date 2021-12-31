using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    public GameObject brokenRock;
    public GameObject brokenRockEffect;

    public IEnumerator RockExplosion()
    { 
        yield return new WaitForSeconds(1.5f);
        Instantiate(brokenRockEffect, transform.position,Quaternion.identity);
        GameObject brokenRockObject = Instantiate(brokenRock, transform.position,Quaternion.identity) as GameObject;
        Rigidbody[] allRigidBodies = brokenRockObject.GetComponentsInChildren<Rigidbody>();
        if (allRigidBodies.Length > 0)
        {
            foreach (var body in allRigidBodies)
            {
                body.AddExplosionForce(500, transform.position,1);
            }
        }
        Destroy(this.gameObject);
    }
    public void StartRockExplosion()
    {
        StartCoroutine(RockExplosion());
    }
}
