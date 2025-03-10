using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject UI_Canvas;
    [SerializeField] GameObject UI_GameLost;
    [SerializeField] GameObject UI_GameWon;
    [SerializeField] private AudioClip bgMusic;
    private GameObject mainCamera;
    private AudioSource bgSoundFXSound;
    [SerializeField] AudioClip winSong;
    [SerializeField] AudioClip loseSong;

    public bool GameIsActive = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        GameIsActive = true;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        bgSoundFXSound = SoundFXManager.instance.PlaySoundOnLoop(bgMusic, mainCamera.transform, 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerWinsGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(winSong, mainCamera.transform, 1f);
        GameIsActive = false;
        Instantiate(UI_GameWon, UI_Canvas.transform, false);
        Time.timeScale = 0;
        bgSoundFXSound.Stop();

    }
    public void PlayerLosesGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(loseSong, mainCamera.transform, 1f);
        GameIsActive = false;
        Instantiate(UI_GameLost, UI_Canvas.transform, false);
        Time.timeScale = 0;
        bgSoundFXSound.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
