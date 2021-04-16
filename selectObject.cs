using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectObject : MonoBehaviour {
    public RaycastHit hit;
	bool holding;
    bool showText = false;
	GameObject heldObject;

    public GameObject lHand;
    public Text text;

    //ray pointing from the centre of the screen
    private Ray centreRay()
    {
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    }


    void Start () {
	}
	
	void Update () {
		if(holding){
			hold(heldObject);
            checkDrop();
			}
		else{
			pickup();
		}
        read();
        keyPadInteract();
        sunDial();
    }

    //moves the selected game object to the position of the lHand
    //you need to set an empty game object as a child of FPS controller, set it to an appropriate position for a left hand...
    //attatch that lHand object as the public lHand for this script
	void hold(GameObject o){
        o.transform.position = lHand.transform.position;
    }

    //if the centre ray hits an object tagged as pickupable it will assign it to heldObject
	void pickup(){
		if(holding == false && Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(centreRay(), out hit, 10)){
				if(hit.collider.tag == "pickupable"){
					holding = true;
					heldObject = hit.transform.gameObject;
                    heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;    
                }                            
            }
		}
	}


    //if the centre ray hits an object with writing on it, it will set the ui text to the text within the object
    void read()
    {
        if (showText == false && Input.GetKeyDown(KeyCode.E)) 
        { 
            if (Physics.Raycast(centreRay(), out hit, 10))
            {
                if (hit.transform.gameObject.GetComponent<writing>() != null)
                {               
                    text.text = hit.transform.gameObject.GetComponent<writing>().words();
                    showText = true;
                }
            }
        }
        else if(showText == true && Input.GetKeyDown(KeyCode.E))
        {
            showText = false;
            text.text = null;
        }
    }


    void checkDrop() {
        if (Physics.Raycast(centreRay(), out hit, 10) && holding == true && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.GetComponent<bookcase>() != null)
            {
                bookcase();
                holding = false;
            }
            if (hit.transform.gameObject.GetComponent<tree>() != null)
            {
                axe();
                holding = false;
            }
            else
            {
                dropObject();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            dropObject();
        }
    }

    void dropObject(){
        holding = false;
        heldObject = null;
    }
    

    void placeObject()
    { 
                holding = false;
                heldObject.SetActive(false);
                hit.transform.gameObject.GetComponent<placeObject>().isOn = true;
    }

    void keyPadInteract()
    {
        if (Physics.Raycast(centreRay(), out hit, 10) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.GetComponent<keyPad>() != null)
            {
                hit.transform.gameObject.GetComponent<keyPad>().isOn = true;
            }
        }
    }

    void bookcase()
    {
        if (Physics.Raycast(centreRay(), out hit, 10) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.GetComponent<bookcase>() != null)
            {
                heldObject.transform.position = hit.transform.gameObject.transform.GetChild(0).position;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                heldObject = null;
                hit.transform.gameObject.transform.position += Vector3.back;
            }
        }
    }

    void sunDial()
    {
        if (Physics.Raycast(centreRay(), out hit, 10))
        {
            if (hit.transform.gameObject.GetComponent<sunDial>() != null)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    hit.transform.gameObject.transform.Rotate(Vector3.up);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    hit.transform.gameObject.transform.Rotate(Vector3.down);
                }
            }

        }
    }

    void axe()
    {
        if (heldObject != null && heldObject.GetComponent<axe>() != null)
        {
            heldObject.transform.position = hit.point;
            heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            heldObject = null;

            hit.transform.GetComponent<Rigidbody>().isKinematic = false;
            hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 30000, ForceMode.Impulse);
        }

    }


}
