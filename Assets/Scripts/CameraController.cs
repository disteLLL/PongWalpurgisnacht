using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject background;

    private void Start() {
        
        float screenWidth = Screen.currentResolution.width;
        float screenHeight = Screen.currentResolution.height;

        background.transform.localScale = new Vector3(screenWidth, screenHeight, 0);

        float baseOrthographicSize = screenHeight / 2;
        Camera.main.orthographicSize = baseOrthographicSize;
    }
}
