using UnityEngine;

public interface IAttacker
{
    void AttackDamage(float damage);
    Transform GetTransform();
}
     