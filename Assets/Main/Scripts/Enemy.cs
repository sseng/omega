using UnityEngine;

class Enemy : MonoBehaviour, IDamageable, IAttacker
{
    public float hp = 20;
    private Transform m_transform;
    private float m_attackDamage;
    private ActionBehavior attack;
    private GameObject m_bullet;

    void Start()
    {
        m_transform = gameObject.transform;
        m_bullet = Resources.Load("bullet") as GameObject;
        Vector3 bulletDirection = new Vector3(0, 0, -0.15f);
        Bullet enemyBullet = m_bullet.GetComponent<Bullet>();

        enemyBullet.SetDirection(bulletDirection);
        enemyBullet.SetDamage(m_attackDamage);
        
        attack = new ActionBehavior(this, m_bullet, 1f);
        AttackDamage(5);
    }

    void Update()
    {
        attack.ActionTimer();
        attack.Attack();
        checkHealth();
    }

    private void checkHealth()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public void AttackDamage(float damage)
    {
        m_attackDamage = damage;
    }

    public Transform GetTransform()
    {
        return m_transform;
    }
}