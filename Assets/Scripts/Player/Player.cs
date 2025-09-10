using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public HealthComponent healthComponent;
    public InputComponent inputComponent;
    public MovementComponent movementComponent;
    public DashComponent dashComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStatus.Reset();
        
        healthComponent.SetHealthPoint(playerStatus.healthPoint);
        dashComponent.SetProperties(playerStatus);
        movementComponent.SetActiveMoveSpeed(playerStatus.moveSpeed);
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
                movementComponent.SetActiveMoveSpeed(playerStatus.dashSpeed);
            }
        }

        if (dashComponent.IsDone())
        {
            movementComponent.SetActiveMoveSpeed(playerStatus.moveSpeed);
        }
    }
}
