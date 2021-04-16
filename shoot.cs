using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject payload;
    public GameObject firingPoint;
    public float thrust;

    private GameObject PLInst;

    private void onTriggerEnter(Collider col) { 
        if(col.gameObject.tag == "Player")
            PLInst = Instantiate(payload, firingPoint.transform.position, Quaternion.identity);
            PLInst.GetComponent<Rigidbody>().AddForce(transform.up * thrust);
        
    }
}
