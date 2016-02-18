using UnityEngine;
using System.Collections;

public class ActionBehavior {
    private Vehicle m_actor;
    private GameObject m_bullet;
    private float m_fireRate;
    private float m_offsetZ;
    private float m_timer;

    public ActionBehavior(Vehicle actor, GameObject bullet, float fireRate)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_offsetZ = 0.5f;
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
        Vector3 spawnOffset = m_actor.transform.position;
        spawnOffset.z += m_offsetZ;
        GameObject.Instantiate(m_bullet, spawnOffset, m_actor.transform.rotation);
    }
}