using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    public int goalToWin;
    public float textFlashDuration = 0.5f;
    public int textFlashFontSize = 150;
    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;
    public AudioClip goal1;
    public AudioClip goal2;
    public AudioClip goal3;
    public AudioClip gameOverWitch;
    public AudioClip gameOverDevil;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private int defaultFontSizePlayer1;
    private int defaultFontSizePlayer2;
    private Text uiScorePlayer1;
    private Text uiScorePlayer2;
    private bool isWinnerPlayer1 = false;
    private bool isWinnerPlayer2 = false;

    private void Awake() {

        uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
        defaultFontSizePlayer1 = uiScorePlayer1.fontSize;
        defaultFontSizePlayer2 = uiScorePlayer2.fontSize;
    }
 
    private void Update() {

        if (isWinnerPlayer1) {

            PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p1")+" is the winner!");
            PlayerPrefs.SetInt("winnerIndex", 0);
            StartCoroutine(ChangeLevel());
        }
        else if (isWinnerPlayer2) {

            PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p2") + " is the winner!");
            PlayerPrefs.SetInt("winnerIndex", 1);
            StartCoroutine(ChangeLevel());
        }
    }

    public void GoalPlayer1() {

        this.scorePlayer1++;

        if (this.scorePlayer1 >= this.goalToWin) {
            isWinnerPlayer1 = true;
            SoundController.instance.PlayRandomizedSound(gameOverWitch);
        }
        else {
            SoundController.instance.PlayRandomizedSound(goal1);
        }

        uiScorePlayer1.text = this.scorePlayer1.ToString();
        StartCoroutine(this.TextFlash(true));

    }

    public void GoalPlayer2() {

        this.scorePlayer2++;

        if (this.scorePlayer2 >= this.goalToWin) {
            isWinnerPlayer2 = true;
            SoundController.instance.PlayRandomizedSound(gameOverDevil);
        }
        else {
            SoundController.instance.PlayRandomizedSound(goal2, goal3);
        }

        uiScorePlayer2.text = this.scorePlayer2.ToString();
        StartCoroutine(this.TextFlash(false));
    }

    private IEnumerator TextFlash(bool isPlayer1) {

        if (isPlayer1) {
            uiScorePlayer1.fontSize = textFlashFontSize;
        }
        else {
            uiScorePlayer2.fontSize = textFlashFontSize;
        }
        
        yield return new WaitForSeconds(textFlashDuration);

        if(isPlayer1) {
            uiScorePlayer1.fontSize = defaultFontSizePlayer1;
        }
        else {
            uiScorePlayer2.fontSize = defaultFontSizePlayer2;
        }
    }

    private IEnumerator ChangeLevel() {

        yield return new WaitForSeconds(0.6f);

        float fadeTime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }
}
