using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Collectable") {
            Destroy(collision.gameObject);
        }
    }
}
