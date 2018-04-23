using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void MoveToScene(int sceneID) {
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
