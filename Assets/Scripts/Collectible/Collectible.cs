using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Player player = collision.gameObject.GetComponent<Player>();
            player.playerStatus.GainCollectible();
            audioSource.PlayOneShot(clip, 1f);
            Destroy(gameObject, clip.length);
        }
    }
}
