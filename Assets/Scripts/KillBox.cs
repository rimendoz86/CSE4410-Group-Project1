using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth player = collision.gameObject.GetComponent<playerHealth>();
            Movement movement = collision.gameObject.GetComponent<Movement>();

            if (player != null && movement != null)
            {
                movement.GetHurt(Vector2.zero); 
                StartCoroutine(KillPlayerAfterDelay(player, movement)); 
            }
        }
    }

    private IEnumerator KillPlayerAfterDelay(playerHealth player, Movement movement)
    {
        movement.IsHurt = true; 
        yield return new WaitForSeconds(0.05f); 

        player.InstaKill(); 
    }
}

