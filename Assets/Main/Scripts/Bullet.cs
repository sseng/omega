using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
    public float timeToLive =  5f;
    public float m_damage = 10;
    public string m_tag;
    private Vector3 m_direction;

    void Update() 
    {
        this.transform.position += m_direction;
        Destroy(this.gameObject, timeToLive);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == m_tag)
        {
            other.GetComponent<IDamageable>().TakeDamage(m_damage);
            Destroy(this.gameObject);
        }
    }

    public void SetDamage(float damage)
    {
        m_damage = damage;
    }

    public void SetDirection(Vector3 direction)
    {
        m_direction = direction;
    }

    public void SetTag(string tag)
    {
        m_tag = tag;
    }
}