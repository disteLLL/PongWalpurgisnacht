using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClipChanger : MonoBehaviour {

    public VideoClip[] videoClips;

    private VideoPlayer videoPlayer;

    private void Awake() {
        videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
    }

    // Use this for initialization
    void Start () {
        videoPlayer.clip = videoClips[2];
    }
}
