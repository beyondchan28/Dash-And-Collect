using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthComponent healthComponent;
    public InputComponent inputComponent;
    public MovementComponent movementComponent;
    public DashComponent dashComponent;

    public float moveSpeed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementComponent.SetActiveMoveSpeed(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        inputComponent.ProcessInput();
        Vector2 moveInput = inputComponent.GetMoveInput();

        movementComponent.Move(moveInput);

        if (inputComponent.DashInputPressed())
        {
            if (dashComponent.IsCanDash())
            {
                movementComponent.SetActiveMoveSpeed(dashComponent.dashSpeed);
            }
        }

        if (dashComponent.IsDone())
        {
            movementComponent.SetActiveMoveSpeed(moveSpeed);
        }
    }
}
