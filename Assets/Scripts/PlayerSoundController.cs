using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour {

    public AudioSource pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Collectable") {
            this.pickUpSound.Play();
        }
    }
}
