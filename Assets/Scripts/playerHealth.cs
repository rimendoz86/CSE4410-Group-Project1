using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    private GameLogic gameLogic;
    private Animator playerAnimator;
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
        movement = GetComponent<Movement>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && gameLogic.GameIsActive)
        {
            gameLogic.PlayerLosesGame();
        }
    }

    public void TakeDamage(float damageAmount, Vector2 knockbackForce)
    {
        if (health <= 0) return;
        health -= damageAmount;

        if (movement != null)
        {
            movement.GetHurt(knockbackForce);
        }

        if (health <= 0)
        {
            StartCoroutine(HandleDeath());
        }
    }

    public void InstaKill()
    {
        if (movement != null)
        {
            movement.GetHurt(Vector2.zero);
        }
        StartCoroutine(HandleDeath());
    }
    private IEnumerator HandleDeath()
    {
        if (playerAnimator != null)
        {
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
            {
                playerAnimator.SetTrigger("isHurt");
            }
        }
        movement.IsHurt = true;
        yield return new WaitForSeconds(0.05f);
        health = 0;
        gameLogic.PlayerLosesGame();
    }
}
