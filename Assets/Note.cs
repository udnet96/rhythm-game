using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    Rigidbody2D rb;
    public float fps, speed; // speed는 1초에 가는 거리
    bool called = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		fps = 1 / Time.deltaTime;
    }
	
	void Update () {
        if(PlayerPrefs.GetInt("Start") == 1 && !called){
            rb.velocity = new Vector2(0, -speed);
            called = true;    
        }
		
	}
}
