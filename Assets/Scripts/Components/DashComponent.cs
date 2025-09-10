using UnityEngine;

public class DashComponent : MonoBehaviour
{
    private float dashCounter = 0f;
    private float dashCoolCounter = 0f;
    private float dashLast, dashCooldown;

    private bool isCooldown = false;

    public void SetProperties(PlayerStatus ps)
    {
        dashCooldown = ps.dashCooldown;
        dashLast = ps.dashLast;
    }

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
