using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.Video.VideoPlayer))]
public class GetMainCam : MonoBehaviour {

    private void Awake() {
        GetComponent<UnityEngine.Video.VideoPlayer>().targetCamera = Camera.main;
    }
}