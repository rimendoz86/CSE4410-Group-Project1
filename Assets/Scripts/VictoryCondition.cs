using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    private GameLogic gameLogic;
    [SerializeField] private AudioClip victorySoundClip;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
        
        SoundFXManager.instance.PlaySoundFXClip(victorySoundClip, transform, 1f);
    }
    
    
    
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            gameLogic.PlayerWinsGame();
        }
    }
}
