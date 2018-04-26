using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour {
	
    public void Collect(GameObject collectable, bool isPlayer1) {

        Collectable collectableScript = collectable.GetComponent<Collectable>();

        string collectableType = collectableScript.collectableType;

        this.gameObject.GetComponent<PowerUpController>().ActivatePowerUp(isPlayer1, collectableType);

        if(collectableType != "death") {
            this.gameObject.GetComponent<PowerUpCooldown>().StartCooldown(isPlayer1, collectableType);
        }
       
        Destroy(collectable);
    }

}
