using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinManager cm;
    public keyManager km;
    public GameObject keyPrefab;

    private bool keySpawned = false;
    [SerializeField] private AudioClip coinPickClip;
  
    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("GameController").GetComponent <CoinManager>();       
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            cm.coinCount++;
            SoundFXManager.instance.PlaySoundFXClip(coinPickClip, transform, 1f);
            if (cm.coinCount == 10 && !keySpawned)
            {
                cm.coinCount = 0;
                Vector3 keyPosition = new Vector3(39, -2.12f, 0.20f);
                Instantiate(keyPrefab, keyPosition, Quaternion.identity);

                keySpawned = true;
            }
        }
    }
}
