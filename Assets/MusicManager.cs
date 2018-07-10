using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	bool called = false;


	void Update () {
		if(PlayerPrefs.GetInt("Strat") == 1 && !called){
            GetComponent<AudioSource>().Play();
            called = true;    
        }
	}
}
