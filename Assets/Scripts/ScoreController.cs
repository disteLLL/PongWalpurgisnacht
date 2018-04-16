﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin;

    // Update is called once per frame
    void Update () {
		if(this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin) {
            SceneManager.LoadScene(1); 
        }
	}

    private void FixedUpdate() {
        Text uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer1.text = this.scorePlayer1.ToString();

        Text uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
        uiScorePlayer2.text = this.scorePlayer2.ToString();
    }

    public void goalPlayer1() {
        this.scorePlayer1++;
    }

    public void goalPlayer2() {
        this.scorePlayer2++;
    }
}