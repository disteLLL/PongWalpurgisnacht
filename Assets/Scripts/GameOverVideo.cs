using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameOverVideo : MonoBehaviour {

    public VideoClip[] videoClips;
    public float[] cameraAlphas;

    private VideoPlayer videoPlayer;

    private void Awake() {

        videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
    }

    private void Start() {

        videoPlayer.clip = videoClips[PlayerPrefs.GetInt("winnerIndex")];
        videoPlayer.targetCameraAlpha = cameraAlphas[PlayerPrefs.GetInt("winnerIndex")];

    }

}
