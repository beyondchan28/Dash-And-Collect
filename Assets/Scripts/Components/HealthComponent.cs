using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private int healthPoint = 3;
    void Start()
    {
        Debug.Log("Starting Health Point = " + healthPoint);
    }

    public void SetHealthPoint(int val)
    {
        healthPoint = val;
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public void Hurt()
    {
        healthPoint -= 1;
        if (healthPoint <= 0f)
        {
            Debug.Log(transform.parent.name + " Is DEAD");
        }
        Debug.Log("Health Point After Damaged = " + healthPoint);

    }
} 
