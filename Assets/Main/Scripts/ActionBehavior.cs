using UnityEngine;
using System.Collections;

public class ActionBehavior {
    private IActor m_actor;
    private GameObject m_bullet;
    private float m_fireRate;
    private float m_timer;
    private Vector3 m_offset;
    private Vector3 m_direction;
    private string m_targetTag;

    public ActionBehavior(IActor actor, GameObject bullet, float fireRate, Vector3 direction, string targetTag)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_direction = direction;
        m_targetTag = targetTag;
        m_offset = new Vector3(0, 0, 1);
    }

    public ActionBehavior(IActor actor, GameObject bullet, float fireRate, Vector3 direction, string targetTag, Vector3 offset)
    {
        m_actor = actor;
        m_bullet = bullet;
        m_fireRate = fireRate;
        m_direction = direction;
        m_targetTag = targetTag;
        m_offset = offset;       
    }

    public void ActionTimer()
    {
        m_timer += Time.deltaTime;
    }

    public void PerformAction()
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
        
        GameObject b = GameObject.Instantiate(m_bullet, spawnOffset, m_actor.GetTransform().rotation) as GameObject;
        Bullet bscript = b.GetComponent<Bullet>();
        bscript.SetDamage(m_actor.AttackDamage);
        bscript.SetDirection(m_direction);
        bscript.SetTag(m_targetTag);
    }
}