using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Scriptable Objects/PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashCooldown = 1.0f;
    public float dashLast = 0.5f;
    public float healthPoint = 100f;
    public int collectCount = 0;

    public void GainCollectible()
    {
        collectCount += 1;
    }

    public void Reset()
    {
        collectCount = 0;
    }
}
