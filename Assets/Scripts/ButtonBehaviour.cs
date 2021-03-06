﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {

    public AudioClip gameStart1;
    public AudioClip gameStart2;

    private Button button;

    private void Awake() {
        button = this.gameObject.GetComponent<Button>();
    }

    private void Update() {
        if(Input.GetButtonDown("Submit") && this.name == "RestartButton") {
            button.onClick.Invoke();
        }
        else if(Input.GetButtonDown("NewGame") && this.name == "NewGameButton") {
            button.onClick.Invoke();
        }
    }

    public void MoveToScene(int sceneID) {

        if(this.name == "RestartButton") {
            SoundController.instance.PlayRandomizedSound(gameStart1, gameStart2);
        }

        SceneManager.LoadScene(sceneID);
        StartCoroutine(ChangeLevel(sceneID));
    }

    IEnumerator ChangeLevel(int sceneID) {

        yield return new WaitForSeconds(0.6f);

        float fadeTime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneID);
    }
}
