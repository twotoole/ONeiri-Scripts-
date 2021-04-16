using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunDial : MonoBehaviour {

    public GameObject light;

	// Use this for initialization
	void Start () {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, light.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
	
	// Update is called once per frame
	void Update () {

        light.transform.eulerAngles = new Vector3(light.transform.eulerAngles.x, this.transform.eulerAngles.y, light.transform.eulerAngles.z);

	}
}
