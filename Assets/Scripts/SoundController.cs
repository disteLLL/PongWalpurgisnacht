using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioSource soundSource;

    public static SoundController instance = null;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    private void Awake() {

        if(instance == null) {

            instance = this;
        }
        else if(instance != this) {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Sound(AudioClip[] clips) {

        soundSource.Play();

        yield return new WaitForEndOfFrame();
    }

    public void PlaySound(AudioClip clip) {

        soundSource.clip = clip;
        soundSource.Play();
    }

    public void PlayRandomizedSound(params AudioClip[] clips) {

        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        soundSource.pitch = randomPitch;
        soundSource.clip = clips[randomIndex];

        StartCoroutine(Sound(clips));
    }
}
