using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClipChanger : MonoBehaviour {

    public VideoClip[] videoClips;
    public float[] cameraAlphas;

    private VideoPlayer videoPlayer;
    private static int clipIndex = 0;

    private void Awake() {

        videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
    }

    private void Start () {

        videoPlayer.clip = videoClips[clipIndex];
        videoPlayer.targetCameraAlpha = cameraAlphas[clipIndex];
        clipIndex++;

        if (clipIndex == videoClips.Length) {
            clipIndex = 0;
        }
    }
}
