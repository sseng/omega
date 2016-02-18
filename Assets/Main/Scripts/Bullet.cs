using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
    public float timeToLive =  5f;
    private float m_speed = 10f;
    private float m_damage = 10;
    private Vector3 m_direction;

    void Start()
    {
        m_direction = new Vector3(0, 0, Time.deltaTime * m_speed);
    }
  
    void Update() 
    {
        this.transform.position += m_direction;
        Destroy(this.gameObject, timeToLive);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
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
}