using UnityEngine;
using System.Collections.Generic;

class Enemy : MonoBehaviour, IDamageable, IActor, IMoveable
{
    public float m_hp = 20;
    public float speed = 5;
    private Transform m_transform;
    private ActionBehavior m_attack;
    private GameObject m_bullet;
    private WayPoints m_waypoints;
    private EnemyMovement m_movement;

    void Start()
    {
        //movements
        m_transform = gameObject.transform;
        m_movement = new EnemyMovement(this, m_waypoints);

        //attacks
        m_bullet = Resources.Load("bullet") as GameObject;
        Vector3 bulletDirection = new Vector3(0, 0, -Time.deltaTime * 10);
        Vector3 bulletOffset = new Vector3(0, 0, -1);
        m_attack = new ActionBehavior(this, m_bullet, 1f, 5f, bulletDirection, "Player", bulletOffset);
        m_attack.setBulletSpeed(0.5f);
    }

    void Update()
    {
        m_movement.applyMovement();
        m_attack.actionTimer();
        m_attack.performAction();
        checkHealth();
    }

    public void setMovePoints(WayPoints waypoints)
    {
        m_waypoints = waypoints;
    }

    public void checkHealth()
    {
        if (m_hp <= 0)
        {
            Destroy(gameObject);
        }
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
        destination.x -= speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveRight()
    {
        Vector3 destination = m_transform.position;
        destination.x += speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveUp()
    {
        Vector3 destination = m_transform.position;
        destination.z += speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveDown()
    {
        Vector3 destination = m_transform.position;
        destination.z -= speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void moveNone()
    {
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void moveTo(Vector3 destination)
    {
        m_transform.position = Vector3.MoveTowards(m_transform.position, destination, Time.deltaTime * speed);
    }
}