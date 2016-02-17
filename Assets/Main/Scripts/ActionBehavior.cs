using UnityEngine;
using System.Collections;

public class ActionBehavior {
    private Vehicle m_actor;
    private GameObject m_bullet;
    private float m_speed;
    private float m_cooldown;
    private float m_offsetZ;
    private float timer = 0f;

    public ActionBehavior()
    {
        m_speed = 1;
        m_cooldown = 0.25f;
        m_offsetZ = 0.25f;
    }

    public ActionBehavior(Vehicle actor, GameObject bullet, float speed, float cooldown)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_speed = speed;
        m_cooldown = cooldown;
        m_offsetZ = 0.25f;
    }

	public void Attack() 
    {
        timer += Time.deltaTime;
        if (timer > m_cooldown)
        {
            SpawnBullet();
            timer = 0;
        }
	}

    void SpawnBullet()
    {
        Vector3 spawnOffset = m_actor.transform.position;
        spawnOffset.z += m_offsetZ;
        GameObject.Instantiate(m_bullet, spawnOffset, m_actor.transform.rotation);
    }
}