using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(this.name == "LabelPlayer1") {
            this.GetComponent<Text>().text = PlayerPrefs.GetString("p1");
        }
        else if (this.name == "LabelPlayer2") {
            this.GetComponent<Text>().text = PlayerPrefs.GetString("p2");
        }
        else {
            this.GetComponent<Text>().text = PlayerPrefs.GetString("winner");
        }
	}	
}
