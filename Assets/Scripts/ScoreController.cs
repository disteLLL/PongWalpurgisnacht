using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;
    public int goalToWin;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private Text uiScorePlayer1;
    private Text uiScorePlayer2;
    private bool isWinnerPlayer1 = false;
    private bool isWinnerPlayer2 = false;

    private void Awake() {

        uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
    }
 
    private void Update() {

        if (isWinnerPlayer1) {

            PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p1")+" is the winner!");
            StartCoroutine(ChangeLevel());
        }
        else if (isWinnerPlayer2) {

            PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p2") + " is the winner!");
            StartCoroutine(ChangeLevel());
        }
    }

    public void GoalPlayer1() {

        this.scorePlayer1++;

        if (this.scorePlayer1 >= this.goalToWin) {
            isWinnerPlayer1 = true;
        }

        uiScorePlayer1.text = this.scorePlayer1.ToString();
        StartCoroutine(this.TextFlash(true));

    }

    public void GoalPlayer2() {

        this.scorePlayer2++;

        if (this.scorePlayer2 >= this.goalToWin) {
            isWinnerPlayer2 = true;
        }

        uiScorePlayer2.text = this.scorePlayer2.ToString();
        StartCoroutine(this.TextFlash(false));
    }

    private IEnumerator TextFlash(bool isPlayer1) {

        if (isPlayer1) {
            uiScorePlayer1.fontSize = 150;
        }
        else {
            uiScorePlayer2.fontSize = 150;
        }
        
        yield return new WaitForSeconds(0.2f);

        if(isPlayer1) {
            uiScorePlayer1.fontSize = 80;
        }
        else {
            uiScorePlayer2.fontSize = 80;
        }
    }

    private IEnumerator ChangeLevel() {

        yield return new WaitForSeconds(0.6f);

        float fadeTime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }
}
