using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletScript : MonoBehaviour
{
    private GameObject player;
    public GameLogic gameLogic;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private Vector2 bulletVelocity;
    [SerializeField] AudioClip damageSound;

    void Start()
    {
        StartCoroutine(InitializeBullet());
    }

    IEnumerator InitializeBullet()
    {
        yield return new WaitForEndOfFrame(); // Ensure components are initialized

        rb = GetComponent<Rigidbody2D>();
        if (rb == null) yield break;

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) yield break;

        gameLogic = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<GameLogic>();
        if (gameLogic == null) yield break;

        // Calculate bullet direction towards player
        Vector3 direction = player.transform.position - transform.position;
        bulletVelocity = new Vector2(direction.x, direction.y).normalized * force;
        rb.velocity = bulletVelocity;

        // Rotate bullet to face the player
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void Update()
    {
        if (gameLogic == null || rb == null) return;
        if (!gameLogic.GameIsActive)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = bulletVelocity;
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth player = other.gameObject.GetComponent<playerHealth>();
            if (player != null && player.health > 0)
            {
                Vector2 knockback = new Vector2(-2f, 1f);
                SoundFXManager.instance.PlaySoundFXClip(damageSound, gameObject.transform, 1f);
                player.TakeDamage(2, knockback);
            }
        }

        if (!other.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }
    }
}
