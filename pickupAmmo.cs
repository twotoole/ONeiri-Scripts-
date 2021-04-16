using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pickupAmmo : MonoBehaviour {
    public RaycastHit hit;

    public Text text;
    public int ammo = 0;

    public GameObject LargeAmmo;
    public GameObject SmallAmmo;
    public GameObject playerAmmo;

    private Ray centreRay()
    {
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    }


    //if the centre ray hits an object tagged as pickupable it will assign it to heldObject
    void pickup()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(centreRay(), out hit, 10))
            {
                if (hit.collider.tag == "pickupable")
                {
                    if(hit.collider.transform.lossyScale.x > 0.5)
                    {
                        playerAmmo.GetComponent<shootWithAmmo>().payload = LargeAmmo;
                    }
                    else
                    { 
                            playerAmmo.GetComponent<shootWithAmmo>().payload = SmallAmmo;
                    }
                    Destroy(hit.transform.gameObject);
                    ammo++;
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pickup();
        text.text = ammo.ToString();
    }
}
