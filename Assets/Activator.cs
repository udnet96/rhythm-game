using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note, gm;
    Color old;
    public bool createMode, autoMode, ParsingMode;
    public GameObject n;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager");
        old = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
                Instantiate(n, transform.position, Quaternion.identity);
        }
        else if (autoMode){
            if (active){
                Destroy(note);
                gm.GetComponent<GameManeger>().AddStreak();
                AddScore();
                active = false;
            }
        }
        else if (ParsingMode){
            PlayerPrefs.SetInt("Life", 10);
			if (Input.GetKeyDown(key)){
				Instantiate(n, transform.position = new Vector3(0,0,0), Quaternion.identity);
            } 
			// bms 파일을 읽어서 그 내용대로 노트를 생성하는 방향으로 수정..
        }
        else {
            if (Input.GetKeyDown(key))
                StartCoroutine(Pressed());
        
            if (Input.GetKeyDown(key) && active)
            {

                Destroy(note);
                gm.GetComponent<GameManeger>().AddStreak();
                AddScore();
                active = false;
            } else if (Input.GetKeyDown(key) && !active)
            {
                gm.GetComponent<GameManeger>().ResetStreak();
            }
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Note"){
            note = collision.gameObject;
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;

    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManeger>().GetScore());
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }

}
