using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    GameLogic gameLogic;
    private float timer;
    private GameObject player;
    [SerializeField] AudioClip canonSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameLogic.GameIsActive) return;
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 10)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                SoundFXManager.instance.PlaySoundFXClip(canonSound, gameObject.transform, 1f);
                shoot();
            }
        }        
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
