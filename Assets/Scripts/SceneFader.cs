using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 0.0f;
    private int fadeDir = -1;
    private static bool preventFirstFade = true;

    private void OnGUI() {

        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade (int direction) {
        fadeDir = direction;
        return fadeSpeed;
    }

    private void OnEnable() {  
        SceneManager.sceneLoaded += OnLevelFinishedLoading;       
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if(preventFirstFade && scene.name == "Start") {
            preventFirstFade = false;           
        }
        else {
            alpha = 1.0f;
            BeginFade(-1);
        }
    }
}
