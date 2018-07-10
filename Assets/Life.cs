using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	float rm;
	GameObject needle;

	// Use this for initialization
	void Start () {
		needle = transform.Find("Needle").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		rm = PlayerPrefs.GetInt("Life"); 
		// Now starting life is 50.
		needle.transform.localPosition = new Vector3(0, (rm-25)/25, 0);
	}
}
