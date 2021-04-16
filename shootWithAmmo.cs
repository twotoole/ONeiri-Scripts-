using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootWithAmmo : MonoBehaviour {

    public GameObject payload;
    public GameObject parent;
    public float thrust;

    private GameObject PLInst;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    thrust++;
        //}
        //if (Input.GetKey(KeyCode.DownArrow) && thrust > 0)
        //{
        //    thrust--;
        //}

        if (Input.GetKeyDown("f") && GetComponentInParent<pickupAmmo>().ammo > 0)
        {
            PLInst = Instantiate(payload, parent.transform.position, Quaternion.identity);
            PLInst.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);

            GetComponentInParent<pickupAmmo > ().ammo--;

        }
    }
}
