using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCooldown : MonoBehaviour {

    private GameObject barPlayer1;
    private GameObject barPlayer2;
    private Image image;
    private float powerUpDuration;

    private void Awake() {

        barPlayer1 = GameObject.FindGameObjectWithTag("BarPlayer1");
        barPlayer2 = GameObject.FindGameObjectWithTag("BarPlayer2");
        barPlayer1.SetActive(false);
        barPlayer2.SetActive(false);
        powerUpDuration = this.gameObject.GetComponent<PowerUpController>().powerUpDuration;    
    }

    public void StartCooldown(bool isPlayer1, Color powerUpColor) {

        if (isPlayer1) {

            image = barPlayer1.GetComponent<Image>();
            barPlayer1.SetActive(true);
        }
        else {

            image = barPlayer2.GetComponent<Image>();
            barPlayer2.SetActive(true);
        }

        image.color = powerUpColor;

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown() {

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
