using UnityEngine;

public class Vehicle : IDamageable, IAttacker
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

    private float m_hp;
    private float m_attackDamage;

    public Vehicle()
    {
        m_hp = 100;
        Speed = 1;
    }

    public void TakeDamage(float amount)
    {
        m_hp -= amount;
    }

    public void AttackDamage(float damage)
    {
        m_attackDamage = damage;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}