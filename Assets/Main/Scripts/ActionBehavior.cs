using UnityEngine;
using System.Collections;

public class ActionBehavior {
    private IAttacker m_actor;
    private GameObject m_bullet;
    private float m_fireRate;
    private float m_timer;
    private Vector3 m_offset;

    public ActionBehavior(IAttacker actor, GameObject bullet, float fireRate)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_offset = new Vector3(0, 0, 1);
    }

    public ActionBehavior(Vehicle actor, GameObject bullet, float fireRate, Vector3 offset)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_offset = offset;       
    }

    public void ActionTimer()
    {
        m_timer += Time.deltaTime;
    }

    public void Attack()
    {
        if (m_timer > m_fireRate)
        {
            SpawnBullet();
            m_timer = 0;
        }
    }

    void SpawnBullet()
    {
        Vector3 spawnOffset = m_actor.GetTransform().position;            
        spawnOffset.z += m_offset.z;
        GameObject.Instantiate(m_bullet, spawnOffset, m_actor.GetTransform().rotation);
    }
}