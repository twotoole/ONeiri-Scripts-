using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispense : MonoBehaviour {

    public GameObject payload;
    public GameObject parent;

    private GameObject PLInst;
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("roller(Clone)") == null) {
            PLInst = Instantiate(payload, parent.transform.position, Quaternion.identity);
        }
	}
}
