using UnityEngine;

public class Vehicle : IDamageable
{
    public Transform transform
    {
        get;
        set;
    }

    public float Hp
    {
        get;
        set;
    }

    public float Speed
    {
        get;
        set;
    }

    public Vehicle()
    {
        Hp = 100;
        Speed = 1;
    }

    public void TakeDamage(float amount)
    {
        Hp -= amount;
    }
}