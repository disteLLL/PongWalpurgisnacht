using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundController : MonoBehaviour {

    public AudioSource wallSound;
    public AudioSource racketSound;
    public AudioSource pointSound;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Racket1" || collision.gameObject.name == "Racket2") {
            this.racketSound.Play();
        }
        else if(collision.gameObject.name == "WallLeft" || collision.gameObject.name == "WallRight") {
            this.pointSound.Play();
        }
        else {
            this.wallSound.Play();
        }
    }
}
