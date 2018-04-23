using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpController : MonoBehaviour {

    public CollisionController collisionController;
    public GameObject racket1;
    public GameObject racket2;
    public float powerUpDuration;
    public float increaseAmount;
    public float decreaseAmount;
    public float speedAmount;
    public bool powerUpActive;

    bool isPlayer1; 
    bool isScaleOriginalIncrease = true;
    bool isScaleOriginalDecrease = true;
    float activeUntilTime = 0f;
    string powerUpType;
    Vector3 originalScale;

	// Use this for initialization
	void Start () {
        originalScale = racket1.transform.lossyScale;
	}
	
	void FixedUpdate () {
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

                collisionController.speedPowerUp = true;
                collisionController.speedPowerUpAmount = this.speedAmount;

                if (isPlayer1) {
                    collisionController.isPlayer1 = true;
                }
                else {
                    collisionController.isPlayer1 = false;
                }               
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
            collisionController.speedPowerUp = false;
        }
    }

    public void ActivatePowerUp(bool isPlayer1, string powerUpType) {
        this.isPlayer1 = isPlayer1;
        this.powerUpActive = true;
        this.powerUpType = powerUpType;
        this.activeUntilTime = Time.time + this.powerUpDuration;
    }

    IEnumerator ChangeLevel() {

        yield return new WaitForSeconds(0.6f);

        float fadeTime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }
}
