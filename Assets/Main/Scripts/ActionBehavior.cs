using UnityEngine;
using System.Collections;

public class ActionBehavior {
    private IActor m_actor;
    private GameObject m_bullet;
    private float m_fireRate;
    private float m_timer;
    private float m_projectileSpeed = 1;
    private float m_attackDamage;
    private Vector3 m_offset;
    private Vector3 m_direction;
    private string m_targetTag;

    public ActionBehavior(IActor actor, GameObject bullet, float fireRate, float damage, Vector3 direction, string targetTag)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_attackDamage = damage;
        m_direction = direction;
        m_targetTag = targetTag;
        m_offset = new Vector3(0, 0, 1);
    }

    public ActionBehavior(IActor actor, GameObject bullet, float fireRate, float damage, Vector3 direction, string targetTag, Vector3 offset)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_attackDamage = damage;
        m_direction = direction;
        m_targetTag = targetTag;
        m_offset = offset;       
    }

    void spawnBullet()
    {
        Vector3 spawnOffset = m_actor.getTransform().position;            
        spawnOffset.z += m_offset.z;
        
        GameObject b = GameObject.Instantiate(m_bullet, spawnOffset, m_actor.getTransform().rotation) as GameObject;
        Bullet bscript = b.GetComponent<Bullet>();
        bscript.setDamage(m_attackDamage);
        bscript.setDirection(m_direction);
        bscript.setTag(m_targetTag);
        bscript.setSpeed(m_projectileSpeed);
    }

    public void actionTimer()
    {
        m_timer += Time.deltaTime;
    }

    public void performAction()
    {
        if (m_timer > m_fireRate)
        {
            spawnBullet();
            m_timer = 0;
        }
    }

    public void setBulletSpeed(float speedMultiplier)
    {
        m_projectileSpeed = speedMultiplier;
    }

    public void setDamage(float damage)
    {
        m_attackDamage = damage;
    }
}