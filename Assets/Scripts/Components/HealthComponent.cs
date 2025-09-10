using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float healthPoint = 100;
    void Start()
    {
        Debug.Log("Starting Health Point = " + healthPoint);
    }

    public void SetHealthPoint(float val)
    {
        healthPoint = val;
    }

    public float GetHealthPoint()
    {
        return healthPoint;
    }

    public void Hurt(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0f)
        {
            Debug.Log(transform.GetComponentInParent<Transform>().name + " Is DEAD");
        }
        Debug.Log("Health Point After Damaged = " + healthPoint);

    }
} 
