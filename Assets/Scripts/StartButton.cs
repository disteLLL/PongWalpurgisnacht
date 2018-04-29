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

    private GameObject labelPlayer1;
    private GameObject labelPlayer2;
    private string namePlayer1;
    private string namePlayer2;

    private void Awake() {

        labelPlayer1 = GameObject.Find("LabelPlayer1");
        labelPlayer2 = GameObject.Find("LabelPlayer2");
    }

    public void MoveToSceneWithNames(int sceneID) {

        if(inputFieldPlayer1.text == "") {
            namePlayer1 = labelPlayer1.GetComponent<Text>().text;
            
        }
        else {
            namePlayer1 = inputFieldPlayer1.text;
        }

        if (inputFieldPlayer2.text == "") {
            namePlayer2 = labelPlayer2.GetComponent<Text>().text;
        }
        else {
            namePlayer2 = inputFieldPlayer2.text;
        }

        PlayerPrefs.SetString("p1", namePlayer1);
        PlayerPrefs.SetString("p2", namePlayer2);
        SceneManager.LoadScene(sceneID);
    }
}
