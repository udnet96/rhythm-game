using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PPTextFloat : MonoBehaviour {

    public string name2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = PlayerPrefs.GetFloat(name2)+"";
	}
}
