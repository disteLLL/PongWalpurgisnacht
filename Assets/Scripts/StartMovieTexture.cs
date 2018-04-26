using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMovieTexture : MonoBehaviour {

    private MovieTexture movie;

	// Use this for initialization
	void Start () {
        movie = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
        movie.loop = true;
        movie.Play();
    }
}
