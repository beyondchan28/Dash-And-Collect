using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Scriptable Objects/EnemyStatus")]
public class EnemyStatus : ScriptableObject
{
    public float moveSpeed = 2f;
    public float stopTime = 2f;   
}
