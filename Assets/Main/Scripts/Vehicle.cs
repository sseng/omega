using UnityEngine;

public class Vehicle : IDamageable
{
    public Transform transform
    {
        get;
        set;
    }

    public float Speed
    {
        get;
        set;
    }

    private float hp;

    public Vehicle()
    {
        hp = 100;
        Speed = 1;
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
    }
}