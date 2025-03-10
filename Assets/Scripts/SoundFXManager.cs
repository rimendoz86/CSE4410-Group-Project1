using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;
    // Start is called before the first frame update
    public void Awake() {
        instance = this;
    }

    public AudioSource PlaySoundOnLoop(AudioClip audioClip, Transform spawnTransform, float volume) {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.loop = true;

        audioSource.Play();

        return audioSource;
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume) 
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length; 

        Destroy(audioSource.gameObject, clipLength);

    }
}
