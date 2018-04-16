using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float movementSpeed;
    public PowerUpController powerUpController;
    //public float extraSpeedPerHit;
    //public float maxExtraSpeed;

    //int hitCounter;

	// Use this for initialization
	void Start () {
        StartCoroutine(this.StartBall());
	}

    void PositionBall (bool isStartingPlayer1) {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if(isStartingPlayer1) {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true) {

        this.PositionBall(isStartingPlayer1);

        powerUpController.powerUpActive = false;
        Destroy(GameObject.FindGameObjectWithTag("Collectable"));

        //this.hitCounter = 0;

        yield return new WaitForSeconds(2);

        if(isStartingPlayer1) {
            this.MoveBall(new Vector2(-1, 0));
        }
        else {
            this.MoveBall(new Vector2(1, 0));
        }
    }
	
	public void MoveBall(Vector2 dir) {

        dir = dir.normalized;

        //float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = dir * movementSpeed;
    }

    public void MoveBallWithSpeed(Vector2 dir, float movementSpeed) {

        dir = dir.normalized;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = dir * (this.movementSpeed + movementSpeed);
    }

    /*public void IncreaseHitCounter() {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed) {
            this.hitCounter++;
        }
    }*/
}
