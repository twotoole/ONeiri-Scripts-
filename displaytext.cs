using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displaytext : MonoBehaviour {

	public Text displayText;

	public void DisplayText() {
		//if (Input.GetKeyDown (KeyCode.E)) {
		displayText.text = "object picked up";
		//}
	}
	void Start() {
		//displayText.text = "";
	}

	void Update() {
		
		if(Input.GetKeyDown(KeyCode.E)) {
			StartCoroutine (FadeTextToFullAlpha (1f,GetComponent<Text> ()));
			DisplayText ();
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
			StartCoroutine (FadeTextToZeroAlpha (1f, GetComponent<Text> ()));
			DisplayText ();
		}
	}

	public IEnumerator FadeTextToFullAlpha(float t, Text i) {
		i.color = new Color(i.color.r,i.color.g,i.color.b,0);
		while (i.color.a <1.0f) {
			i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}

	}
	public IEnumerator FadeTextToZeroAlpha (float t, Text i) {
		i.color = new Color (i.color.r, i.color.b, i.color.g, 1);
		while(i.color.a > 0.0f) {
			i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}
}