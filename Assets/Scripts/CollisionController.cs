using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    private float speedPowerUpAmount;
    private bool speedPowerUp = false;
    private bool isPlayer1;
    private Collectables collectables;
    private BallMovement ballMovement;
    private ScoreController scoreController;

    private void Awake() {

        this.collectables = this.gameObject.GetComponentInParent<Collectables>();
        this.ballMovement = this.gameObject.GetComponent<BallMovement>();
        this.scoreController = this.gameObject.GetComponentInParent<ScoreController>();
    }

    private void BounceFromRacket(Collision2D c) {

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
            this.collectables.SpawnRandomCollectable();
        }
        else if(collision.gameObject.name == "Racket2") {

            this.BounceFromRacket(collision);
            this.collectables.SpawnRandomCollectable();
        }
        else if (collision.gameObject.name == "WallLeft") {

            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight") {

            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));    
        }
        else {

            this.collectables.SpawnRandomCollectable();
        }
    }

    public void SetSpeedPowerUp(bool isPlayer1, bool speedPowerUp, float speedPowerUpAmount) {

        this.isPlayer1 = isPlayer1;
        this.speedPowerUp = speedPowerUp;
        this.speedPowerUpAmount = speedPowerUpAmount;
    }
}
