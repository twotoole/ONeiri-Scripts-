using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalInteract : MonoBehaviour{

    public RaycastHit hit;

    public int winCounter = 0;
    public string levelName;

    private Ray centreRay()
    {
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(winCounter == 3)
        {
            Application.LoadLevel(levelName);
        }

        interact();
	}


    void interact()
    {
        if (Physics.Raycast(centreRay(), out hit, 10) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.GetComponent<goal>() != null)
            {
                hit.transform.gameObject.GetComponent<goal>().isOn = true;
                winCounter++;
            }
        }
    }
}
