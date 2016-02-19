using UnityEngine;

class Enemy : MonoBehaviour, IDamageable, IActor
{
    public float hp = 20;
    private Transform m_transform;
    private float m_attackDamage;
    private ActionBehavior attack;
    private GameObject m_bullet;

    public float AttackDamage
    {
        get; set;
    }

    void Start()
    {
        m_transform = gameObject.transform;
        m_bullet = Resources.Load("bullet") as GameObject;
        Vector3 bulletDirection = new Vector3(0, 0, -Time.deltaTime * 10);
        Vector3 bulletOffset = new Vector3(0, 0, -1);
        attack = new ActionBehavior(this, m_bullet, 1f, bulletDirection, "Player", bulletOffset);
        AttackDamage = 5;       
    }

    void Update()
    {
        attack.ActionTimer();
        attack.PerformAction();
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

    public Transform GetTransform()
    {
        return m_transform;
    }
}