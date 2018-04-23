using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour {

    public PowerUpController powerUpController;

	
    public void Collect(GameObject collectable, bool isPlayer1) {

        Collectable collectableScript = collectable.GetComponent<Collectable>();

        string collectableType = collectableScript.collectableType;

        this.powerUpController.ActivatePowerUp(isPlayer1, collectableType);

        Destroy(collectable);
    }

}
