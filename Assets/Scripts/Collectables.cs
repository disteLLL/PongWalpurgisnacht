using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    public GameObject wallTop;
    public GameObject wallBottom;
    public float collectableSpeed;
    public float collectableChance;

    private bool equalPowerUps;
    private float boundsTop;
    private float boundsBottom;
    private Collectable newCollectable;
    private PowerUpController powerUpController;

    private void Awake() {

        powerUpController = this.gameObject.GetComponent<PowerUpController>();
        boundsTop = wallTop.transform.position.y - 50;
        boundsBottom = wallBottom.transform.position.y + 50;
    }

    public void SpawnRandomCollectable(){

        if(Random.value <= collectableChance) {

            if (!(powerUpController.powerUpActive) && (GameObject.FindGameObjectWithTag("Collectable") == null)) {

                float r = Random.value;

                if (r > 0.70f) {
                    newCollectable = Collectable.CreateSpeed();
                }
                else if (r > 0.35f) {
                    newCollectable = Collectable.CreateIncrease();
                }
                else if (r > 0.05f) {
                    newCollectable = Collectable.CreateDecrease();
                }
                else {
                    newCollectable = Collectable.CreateDeath();
                }

                if (equalPowerUps) {

                    newCollectable.gameObject.transform.position = new Vector3(-100.0f, Random.Range(boundsBottom, boundsTop), 0.0f);
                    this.MoveCollectable(new Vector2(-1, 0), newCollectable);
                    equalPowerUps = false;
                }
                else {

                    newCollectable.gameObject.transform.position = new Vector3(100.0f, Random.Range(boundsBottom, boundsTop), 0.0f);
                    this.MoveCollectable(new Vector2(1, 0), newCollectable);
                    equalPowerUps = true;
                }    
            }
        }
    }

    public void MoveCollectable(Vector2 dir, Collectable collectable) {

        dir = dir.normalized;
        Rigidbody2D rigidbody2D = collectable.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = dir * collectableSpeed;
    }

    public Color GetCollectableColor() {

        return newCollectable.gameObject.GetComponent<SpriteRenderer>().color;
    }
}
