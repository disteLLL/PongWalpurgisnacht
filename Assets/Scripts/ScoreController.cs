using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private Text uiScorePlayer1;
    private Text uiScorePlayer2;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin;

    private void Start() {
        uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (this.scorePlayer1 >= this.goalToWin) {
            PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p1")+" is the winner!");
            SceneManager.LoadScene(2);
        }
        else if (this.scorePlayer2 >= this.goalToWin) {
            PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p2") + " is the winner!");
            SceneManager.LoadScene(2);
        }
    }

    public void goalPlayer1() {
        this.scorePlayer1++;
        uiScorePlayer1.text = this.scorePlayer1.ToString();
        StartCoroutine(this.TextFlash(true));

    }

    public void goalPlayer2() {
        this.scorePlayer2++;
        uiScorePlayer2.text = this.scorePlayer2.ToString();
        StartCoroutine(this.TextFlash(false));
    }

    public IEnumerator TextFlash(bool isPlayer1) {
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
}
