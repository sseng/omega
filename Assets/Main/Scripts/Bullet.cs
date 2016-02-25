using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
    public float timeToLive =  5f;
    private float m_damage = 10;
    private float m_speed = 1;
    private string m_tag;
    private Vector3 m_direction;

    void Update() 
    {
        this.transform.position += m_direction * m_speed;
        Destroy(this.gameObject, timeToLive);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == m_tag)
        {
            other.GetComponent<IDamageable>().takeDamage(m_damage);
            Destroy(this.gameObject);
        }
    }

    public void setDamage(float damage)
    {
        m_damage = damage;
    }

    public void setSpeed(float speed)
    {
        m_speed = speed;
    }

    public void setDirection(Vector3 direction)
    {
        m_direction = direction;
    }

    public void setTag(string tag)
    {
        m_tag = tag;
    }
}