using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    public PowerUpController powerUpController;
    public GameObject wallTop;
    public GameObject wallBottom;

    public float collectableSpeed;
    public float collectableChance;

    bool equalPowerUps;
    float boundsTop;
    float boundsBottom;

    private void Start() {
        boundsTop = wallTop.transform.position.y - 50;
        boundsBottom = wallBottom.transform.position.y + 50;
    }


    public void SpawnRandomCollectable(){

        if(Random.value <= collectableChance) {
            if (!(powerUpController.powerUpActive) && (GameObject.FindGameObjectWithTag("Collectable") == null)) {
                float r = Random.value;
                Collectable newCollectable;

                if (r > 0.5f) {
                    newCollectable = Collectable.CreateSpeed();
                }
                else if (r > 0.25f) {
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
}
