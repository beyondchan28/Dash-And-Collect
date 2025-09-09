using UnityEngine;

public class DashComponent : MonoBehaviour
{
    public float dashCounter = 0f;
    public float dashCoolCounter = 0f;
    public float dashSpeed = 15;
    public float dashLast = 0.5f, dashCooldown = 1f;

    private bool isCooldown = false;
    public bool IsCanDash()
    {
        if (dashCoolCounter <= 0f && dashCounter <= 0f)
        {
            dashCounter = dashLast;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsDone()
    {
        if (dashCounter > 0f)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                dashCoolCounter = dashCooldown; // start cooldown
                isCooldown = true;
                return true;
            }
            return false;
        }
        return false;
    }

    public void ProcessCooldown()
    {
        if (dashCoolCounter > 0f)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        else if (dashCoolCounter <= 0f && isCooldown)
        {
            isCooldown = false;
        }
    }

    void Update()
    {
        if (isCooldown)
        {
            ProcessCooldown();
        }    
    }
}
