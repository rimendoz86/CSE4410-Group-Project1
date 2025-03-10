using UnityEngine;

public class heartScript : MonoBehaviour
{
    public playerHealth hm;
    [SerializeField] private AudioClip heartsoundClip;
    // Start is called before the first frame update
    void Start()
    {
        hm = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundFXManager.instance.PlaySoundFXClip(heartsoundClip, transform, 1f);
            Destroy(gameObject);
            hm.health++;
        }
    }
}
