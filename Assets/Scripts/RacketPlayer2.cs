using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2 : MonoBehaviour {

    //public float movementSpeed;
    public CollectionController collectionController;

    /*private void FixedUpdate() {
        float v = Input.GetAxisRaw("Vertical2");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }*/

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Collectable") {
            collectionController.Collect(collision.gameObject, false);
        }
    }
}
