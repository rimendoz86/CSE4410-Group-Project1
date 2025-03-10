using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public keyManager km;
    public Door door;
    public bool isPickedUp;
    [SerializeField] AudioClip coinAudio;
    // Start is called before the first frame update
    void Start()
    {
        km = GameObject.FindGameObjectWithTag("GameController").GetComponent<keyManager>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            SoundFXManager.instance.PlaySoundFXClip(coinAudio, gameObject.transform, 1f);
            Destroy(gameObject);
            isPickedUp = true;
            km.keyCount = 1;

            if (door != null)
            {
            door.UnlockDoor();
            }            
        }
    }
}
