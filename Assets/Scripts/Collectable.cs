using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public string collectableType;

    public static Collectable CreateIncrease(){
        GameObject increase = (GameObject)Instantiate(Resources.Load("Prefabs/Increase"));
        return increase.GetComponent<Collectable>();
    }

    public static Collectable CreateDecrease(){
		GameObject decrease = (GameObject)Instantiate(Resources.Load("Prefabs/Decrease"));
		return decrease.GetComponent<Collectable>();
    }

    public static Collectable CreateSpeed(){
		GameObject speed = (GameObject)Instantiate(Resources.Load("Prefabs/Speed"));
		return speed.GetComponent<Collectable>();
    }
}
