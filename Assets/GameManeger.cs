using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManeger : MonoBehaviour {
	
	float timer = 0;
    int multiplier = 2;
    int streak = 0;
    GameObject note, winnote;
    // Use this for initialization
    void Start() {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Life", 25);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("MaxStreak", 0);
        PlayerPrefs.SetInt("Multiplier", 1);
        PlayerPrefs.SetInt("NotesHit", 0);
        PlayerPrefs.SetInt("Start", 1);
		PlayerPrefs.SetFloat("Time", 0);
    }

    // Update is called once per frame
    void Update() {
		timer += Time.deltaTime;
		PlayerPrefs.SetFloat("Time", Mathf.Round(timer*100)/100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {	
		print (timer);
        if (collision.gameObject.tag == "Note")
            note = collision.gameObject;
        if (collision.gameObject.tag == "WinNote"){
            winnote = collision.gameObject;
            Destroy(winnote);
            Win();
        }
        Destroy(note);
        ResetStreak();
        
    }

    public void AddStreak()
    {   
        if(PlayerPrefs.GetInt("Life") + 2 < 100){
            PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") + 2);
        }
        streak++;
        if (streak >= 24) 
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;

        if(streak > PlayerPrefs.GetInt("MaxStreak"))
            PlayerPrefs.SetInt("MaxStreak", streak);

        PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") + 1);

        UpdateGUI();
    }

    public void ResetStreak()
    {    
        PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") - 4);
        if (PlayerPrefs.GetInt("Life") < -50)
            GameOver();
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void Win(){
        PlayerPrefs.SetInt("Start", 0);
        if(PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        SceneManager.LoadScene(1);

    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Start", 0);
        SceneManager.LoadScene(2);
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Multiplier", multiplier);

    }

    public int GetScore()
    { 
        return 100 * multiplier;
    }
}
