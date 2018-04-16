﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    public BallMovement ballMovement;
    public ScoreController scoreController;
    public float speedPowerUpAmount;
    public bool speedPowerUp = false;
    public bool isPlayer1;

    Collectables collectables;

    private void Start() {
        this.collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent<Collectables>();
    }

    void BounceFromRacket(Collision2D c) {

        Vector3 ballPosition = this.transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float x;
        if(c.gameObject.name == "Racket1") {
            x = 1;
        }
        else {
            x = -1;
        }

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        if (speedPowerUp) {
            if(isPlayer1 && c.gameObject.name == "Racket1") {
                this.ballMovement.MoveBallWithSpeed(new Vector2(x, y), speedPowerUpAmount);
            }
            else if(!isPlayer1 && c.gameObject.name == "Racket2") {
                this.ballMovement.MoveBallWithSpeed(new Vector2(x, y), speedPowerUpAmount);
            }          
        }
        else {
            this.ballMovement.IncreaseHitCounter();
            this.ballMovement.MoveBall(new Vector2(x, y));
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.name == "Racket1") {
            this.BounceFromRacket(collision);
            this.collectables.SpawnRandomCollectable(true);
        }
        else if(collision.gameObject.name == "Racket2") {
            this.BounceFromRacket(collision);
            this.collectables.SpawnRandomCollectable(false);
        }
        else if (collision.gameObject.name == "WallLeft") {
            this.scoreController.goalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight") {
            this.scoreController.goalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}