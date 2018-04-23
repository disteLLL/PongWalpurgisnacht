using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StartButton : MonoBehaviour {

    [SerializeField]
    private InputField inputFieldPlayer1;
    [SerializeField]
    private InputField inputFieldPlayer2;

    private string namePlayer1 = "Player 1";
    private string namePlayer2 = "Player 2";

    public void MoveToSceneWithNames(int sceneID) {
        if(inputFieldPlayer1.text == "") {
            namePlayer1 = "Player 1";
        }
        else {
            namePlayer1 = inputFieldPlayer1.text;
        }

        if (inputFieldPlayer2.text == "") {
            namePlayer2 = "Player 2";
        }
        else {
            namePlayer2 = inputFieldPlayer2.text;
        }

        PlayerPrefs.SetString("p1", namePlayer1);
        PlayerPrefs.SetString("p2", namePlayer2);

        SceneManager.LoadScene(sceneID);
    }
}
