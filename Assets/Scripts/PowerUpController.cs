using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpController : MonoBehaviour {

    public GameObject racket1;
    public GameObject racket2;
    public float powerUpDuration;
    public float increaseAmount;
    public float decreaseAmount;
    public float speedAmount;
    public bool powerUpActive;

    private bool isPlayer1;
    private bool isScaleOriginalIncrease = true;
    private bool isScaleOriginalDecrease = true;
    private float activeUntilTime = 0f;
    private string powerUpType;
    private Vector3 originalScale;
    private CollisionController collisionController;

    private void Awake() {

        originalScale = racket1.transform.lossyScale;
        collisionController = this.gameObject.GetComponentInChildren<CollisionController>();
    }

    private void FixedUpdate () {

        powerUp(isPlayer1);
	}

    private void powerUp(bool isPlayer1) {
        if (powerUpActive && Time.time < this.activeUntilTime) {

            if (this.powerUpType == "increase") {

                if (isScaleOriginalIncrease) {
                    if(isPlayer1) {
                        racket1.transform.localScale += new Vector3(0, increaseAmount, 0);
                    }
                    else {
                        racket2.transform.localScale += new Vector3(0, increaseAmount, 0);
                    } 
                    isScaleOriginalIncrease = false;
                }
            }
            else if (this.powerUpType == "decrease") {

                if (isScaleOriginalDecrease) {
                    if (isPlayer1) {
                        racket2.transform.localScale += new Vector3(0, -decreaseAmount, 0);
                    }
                    else {
                        racket1.transform.localScale += new Vector3(0, -decreaseAmount, 0);
                    }
                    isScaleOriginalDecrease = false;
                }
            }
            else if (this.powerUpType == "speed") {

                collisionController.SetSpeedPowerUp(isPlayer1, true, speedAmount);
            }
            else if (this.powerUpType == "death") {
                
                if (isPlayer1) {
                    PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p2") + " is the winner!");
                    StartCoroutine(ChangeLevel());
                }
                else {
                    PlayerPrefs.SetString("winner", PlayerPrefs.GetString("p1") + " is the winner!");
                    StartCoroutine(ChangeLevel());
                }
            }
        }
        else {

            this.powerUpType = null;
            this.powerUpActive = false;
        }

        if (this.powerUpType != "increase") {

            if (isPlayer1) {
                racket1.transform.localScale = originalScale;
            }
            else {
                racket2.transform.localScale = originalScale;
            }           
            isScaleOriginalIncrease = true;
        }
        if (this.powerUpType != "decrease") {

            if (isPlayer1) {
                racket2.transform.localScale = originalScale;
            }
            else {
                racket1.transform.localScale = originalScale;
            }
            isScaleOriginalDecrease = true;
        }
        if (this.powerUpType != "speed") {

            collisionController.SetSpeedPowerUp(isPlayer1, false, speedAmount);
        }
    }

    private IEnumerator ChangeLevel() {

        yield return new WaitForSeconds(0.6f);

        float fadeTime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }

    public void ActivatePowerUp(bool isPlayer1, string powerUpType) {
        this.isPlayer1 = isPlayer1;
        this.powerUpActive = true;
        this.powerUpType = powerUpType;
        this.activeUntilTime = Time.time + this.powerUpDuration;
    }
}