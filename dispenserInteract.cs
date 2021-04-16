using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dispenserInteract : MonoBehaviour { 

    public RaycastHit hit;

    private Ray centreRay()
    {
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        keyPadInteract();

    }

    void keyPadInteract()
    {
        if (Physics.Raycast(centreRay(), out hit, 10) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.GetComponent<dispenser>() != null)
            {
                hit.transform.gameObject.GetComponent<dispenser>().isOn = true;
            }
        }
    }
}
