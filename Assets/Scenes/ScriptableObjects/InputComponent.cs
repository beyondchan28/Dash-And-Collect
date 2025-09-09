using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private Vector2 moveInput;

    public void ProcessInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }

    public bool DashInputPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
