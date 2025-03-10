using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public bool locked;  // Determines if the door is locked or unlocked
    private GameLogic gameLogic;
    private Animator anim;  // Reference to the Animator for the door
    [SerializeField] private GameObject player;  // Reference to the player GameObject
    public keyManager km; //Reference to key object

    void Start()
    {
        anim = GetComponent<Animator>();  // Attaches the Animator component to the door
        locked = true;  // The door is locked initially
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
        km = GameObject.FindGameObjectWithTag("GameController").GetComponent<keyManager>();
    }

    void Update()
    {
        // Any extra logic can be added if you want to do something while the door is locked
    }

    // Triggers the door opening after the player collects the key
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if the player has collided with the door
        if (other.CompareTag("Player") && !locked)
        {
            km.keyCount = 0;
            // If the player is near the door and it is unlocked, the door opening animation will play
            anim.SetTrigger("Open"); 
            StartCoroutine(DelayThenExecute(() => { gameLogic.PlayerWinsGame(); }, 2.0f));            
        }

        // If the player is near the door and the door is locked, the door should not open
    }

    // Door will unlock when the key is collected
    public void UnlockDoor()
    {
        locked = false;  // Unlocks the door
    }

    // Optional: Closes the door after a certain amount of time or under certain conditions
    public void CloseDoor()
    {
        locked = true;  // Locks the door again
        anim.SetTrigger("Closed");  // Will trigger the door closing animation
    }

    IEnumerator DelayThenExecute(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
