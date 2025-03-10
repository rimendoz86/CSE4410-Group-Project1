using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [Header("--AudioSource--")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--Audio Clip--")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip coin;
    public AudioClip enemyhit;
    public AudioClip jump;
    public AudioClip heart;
    public AudioClip victory;

    private void start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }

}
