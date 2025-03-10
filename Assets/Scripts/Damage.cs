using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{   
    

    public float damage;
    [SerializeField] private AudioClip damageSoundClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth player = other.gameObject.GetComponent<playerHealth>();
            if (player != null && player.health > 0)
            {
                SoundFXManager.instance.PlaySoundFXClip(damageSoundClip, transform, 1f);
                Vector2 knockback = new Vector2(-2f, 1f);
                player.TakeDamage(damage, knockback);
            }

        }        
    
    }
}
