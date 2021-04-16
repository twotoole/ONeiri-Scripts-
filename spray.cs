using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spray : MonoBehaviour {

    public GameObject payload;
    public GameObject parent;
    public float thrust;

    private GameObject PLInst;
    private bool spraying;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            spraying = !spraying;
        }


        if (spraying)
        {
            PLInst = Instantiate(payload, parent.transform.position, Quaternion.identity);
            PLInst.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
        }
    }
}
