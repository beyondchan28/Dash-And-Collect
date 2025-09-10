using System.Linq;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] Collectible collectible;
    private const int COLLECTIBLE_AMOUNT = 20;
    void Start()
    {
        Debug.Log("Screen size : " + Screen.width + "/" + Screen.height);
        foreach (int i in Enumerable.Range(0, COLLECTIBLE_AMOUNT))
        {
            Collectible newCollectible = Instantiate(collectible, transform);
            newCollectible.transform.localPosition = new Vector2(
                Random.Range(-8f, 8f),
                Random.Range(-4f, 4f)
            );
        }
    }

}
