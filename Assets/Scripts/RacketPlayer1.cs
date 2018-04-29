using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour {

    public float movementSpeed;
    public bool testMode = true;

    private CollectionController collectionController;

    private void Awake() {

        collectionController = this.gameObject.GetComponentInParent<CollectionController>();
    }

    private void FixedUpdate() {

        if (testMode) {
            float v = Input.GetAxisRaw("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "Collectable") {
            collectionController.Collect(collision.gameObject, true);
        }
    }
}
