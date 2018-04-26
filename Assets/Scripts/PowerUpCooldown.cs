using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCooldown : MonoBehaviour {

    private GameObject barPlayer1;
    private GameObject barPlayer2;
    private Image image;
    private Sprite green;
    private Sprite red;
    private Sprite yellow;
    private float powerUpDuration;


    private void Start() {
        barPlayer1 = GameObject.FindGameObjectWithTag("BarPlayer1");
        barPlayer2 = GameObject.FindGameObjectWithTag("BarPlayer2");
        barPlayer1.SetActive(false);
        barPlayer2.SetActive(false);
        powerUpDuration = this.gameObject.GetComponent<PowerUpController>().powerUpDuration;
        green = Resources.Load("Sprites/green", typeof(Sprite)) as Sprite;
        red = Resources.Load("Sprites/red", typeof(Sprite)) as Sprite;
        yellow = Resources.Load("Sprites/yellow", typeof(Sprite)) as Sprite;
    }

    public void StartCooldown(bool isPlayer1, string powerUpType) {

        if (isPlayer1) {
            image = barPlayer1.GetComponent<Image>();
            barPlayer1.SetActive(true);
        }
        else {
            image = barPlayer2.GetComponent<Image>();
            barPlayer2.SetActive(true);
        }

        if (powerUpType == "increase") {
            image.sprite = green;
        }
        else if (powerUpType == "decrease") {
            image.sprite = red;
        }
        else if (powerUpType == "speed") {
            image.sprite = yellow;
        }  

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        float elapsedTime = 0f;

        while(elapsedTime < powerUpDuration) {
            elapsedTime += Time.deltaTime;
            image.fillAmount -= 1 / powerUpDuration * Time.deltaTime;
            yield return null;
        }

        HideBar();
        image.fillAmount = 1;
    }

    public void HideBar() {
        barPlayer1.SetActive(false);
        barPlayer2.SetActive(false);
    }
}
