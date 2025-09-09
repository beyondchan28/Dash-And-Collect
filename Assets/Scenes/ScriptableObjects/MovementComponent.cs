using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public Rigidbody2D rb;
    private float activeMoveSpeed;
    public void Move(Vector2 input)
    {
        rb.linearVelocity = input * activeMoveSpeed;
    }

    public void SetActiveMoveSpeed(float speed)
    {
        activeMoveSpeed = speed;
    }

    public float GetActiveMoveSpeed()
    {
        return activeMoveSpeed;
    }

}
