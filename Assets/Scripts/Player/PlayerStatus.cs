using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Scriptable Objects/PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashCooldown = 1.0f;
    public float dashLast = 0.5f;
    public int healthPoint = 3;
    public int collectCount = 0;

    const int WIN_COLLECTIBLE_AMOUNT = 20;

    public void GainCollectible()
    {
        collectCount += 1;
        if (collectCount == WIN_COLLECTIBLE_AMOUNT)
        {
            Debug.Log("YOU WIN !");
        }
    }

    public void Reset()
    {
        collectCount = 0;
        healthPoint = 3;
    }
}
