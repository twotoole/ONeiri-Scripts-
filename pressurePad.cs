using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePad : MonoBehaviour {

    float m=0;

    public List<Rigidbody> weights;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(m);
        if (weights.Count == 0)
        {
            m = 0;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        weights.Add(col.rigidbody);
        checkWeight();

    }

    void OnCollisionExit(Collision col)
    {
        weights.Remove(col.rigidbody);
        checkWeight();
    }

    void checkWeight()
    {
        m = 0;
        if (weights.Count > 0)
        {
            for (int i = 0; i < weights.Count; i++)
            {
                m += weights[i].mass;
                if (m > 8)
                {
                    transform.position -= new Vector3(0, 0.05f, 0);
                }
            }
        }
    }
}
