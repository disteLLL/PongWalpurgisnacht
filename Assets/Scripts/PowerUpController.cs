using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if(isPlayer1) {
            powerUpPlayer1();
        }
        else {
            powerUpPlayer2();
        } 
	}

    private void powerUpPlayer1() {
        if (powerUpActive && Time.time < this.activeUntilTime) {
            if (this.powerUpType == "increase") {
                if (isScaleOriginalIncrease) {
                    racket1.transform.localScale += new Vector3(0, increaseAmount, 0);
                    isScaleOriginalIncrease = false;
                }
            }
            else if (this.powerUpType == "decrease") {
                if (isScaleOriginalDecrease) {
                    racket2.transform.localScale += new Vector3(0, -decreaseAmount, 0);
                    isScaleOriginalDecrease = false;
                }
            }
            else if (this.powerUpType == "speed") {

                collisionController.speedPowerUp = true;
                collisionController.speedPowerUpAmount = this.speedAmount;
                collisionController.isPlayer1 = true;

            }
        }
        else {
            this.powerUpType = null;
            this.powerUpActive = false;
        }

        if (this.powerUpType != "increase") {
            racket1.transform.localScale = originalScale;
            isScaleOriginalIncrease = true;    
        }
        if(this.powerUpType != "decrease") {       
            racket2.transform.localScale = originalScale;
            isScaleOriginalDecrease = true;   
        }
        if (this.powerUpType != "speed") {
            collisionController.speedPowerUp = false;
        }
    }

    private void powerUpPlayer2() {
        if (powerUpActive && Time.time < this.activeUntilTime) {
            if (this.powerUpType == "increase") {
                if (isScaleOriginalIncrease) {
                    racket2.transform.localScale += new Vector3(0, increaseAmount, 0);
                    isScaleOriginalIncrease = false;
                }
            }
            else if (this.powerUpType == "decrease") {
                if (isScaleOriginalDecrease) {
                    racket1.transform.localScale += new Vector3(0, -decreaseAmount, 0);
                    isScaleOriginalDecrease = false;
                }
            }
            else if (this.powerUpType == "speed") {

                collisionController.speedPowerUp = true;
                collisionController.speedPowerUpAmount = this.speedAmount;
                collisionController.isPlayer1 = false;
                
            }
        }
        else {
            this.powerUpType = null;
            this.powerUpActive = false;
        }

        if (this.powerUpType != "increase") {
            racket2.transform.localScale = originalScale;
            isScaleOriginalIncrease = true;
        }
        if (this.powerUpType != "decrease") {
            racket1.transform.localScale = originalScale;
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
}
