using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales : MonoBehaviour {

    public GameObject plat;
    public TextMesh _text;

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

        _text.text = (8-weights.Count).ToString();

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
                    plat.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }

}
