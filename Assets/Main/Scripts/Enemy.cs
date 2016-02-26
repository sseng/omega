using UnityEngine;
using System.Collections.Generic;

class Enemy : MonoBehaviour, IDamageable, IActor, IMoveable
{
    public float m_hp = 20;
    public float moveSpeed = 5;
    public float damage;
    public float fireRate;
    private Transform m_transform;
    private ActionBehavior m_attack;
    private GameObject m_bullet;    
    private WayPoints m_waypoints;
    private EnemyMovement m_movement;
    private Vector3 m_projectileDirection;
    private bool m_isDead;


    void Start()
    {
        //movements
        m_transform = gameObject.transform;
        m_movement = new EnemyMovement(this, m_waypoints);

        //attacks
        m_bullet = Resources.Load("bullet") as GameObject;
        Vector3 bulletOffset = new Vector3(0, 0, 0);
        m_attack = new ActionBehavior(this, m_bullet, fireRate, damage, m_projectileDirection, "Player", bulletOffset);
        m_attack.setBulletSpeed(0.1f);
    }

    void Update()
    {
        m_movement.applyMovement();
        m_attack.actionTimer();
        m_attack.setProjectileDirection(m_projectileDirection);
        m_attack.performAction();
        checkHealth();
    }

    public void setProjectileDirection(Vector3 target)
    {
        m_projectileDirection = (target - gameObject.transform.position).normalized;
    }

    public void setMovePoints(WayPoints waypoints)
    {
        m_waypoints = waypoints;
    }

    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void checkHealth()
    {
        if (m_hp <= 0)
        {
            m_isDead = true;
        }
    }

    public bool isDead()
    {
        return m_isDead;
    }

    public void takeDamage(float damage)
    {
        m_hp -= damage;
    }

    public Transform getTransform()
    {
        return m_transform;
    }

    public void moveLeft()
    {
        Vector3 destination = m_transform.position;
        destination.x -= moveSpeed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveRight()
    {
        Vector3 destination = m_transform.position;
        destination.x += moveSpeed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveUp()
    {
        Vector3 destination = m_transform.position;
        destination.z += moveSpeed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveDown()
    {
        Vector3 destination = m_transform.position;
        destination.z -= moveSpeed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveNone()
    {
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void moveTo(Vector3 destination)
    {
        m_transform.position = Vector3.MoveTowards(m_transform.position, destination, Time.deltaTime * moveSpeed);
    }
}