using UnityEngine;

public class Vehicle : IDamageable, IActor, IMoveable
{
    private float m_speed;
    private float m_hp;
    private float m_rotateAngle = 60;
    private Transform m_transform;

    public Vehicle(float hp, float speed, Transform transform)
    {
        m_hp = hp;
        m_speed = speed;
        m_transform = transform;
    }

    public float GetHp()
    {
        return m_hp;
    }

    public void takeDamage(float amount)
    {
        m_hp -= amount;
    }

    public Transform getTransform()
    {
        return m_transform;
    }

    public void moveLeft()
    {
        Vector3 targetAngle = new Vector3(0, 0, m_rotateAngle);
        rotateAngle(targetAngle);

        Vector3 destination = m_transform.position;
        destination.x -= 1;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime * m_speed);
    }

    public void moveRight()
    {
        Vector3 targetAngle = new Vector3(0, 0, -m_rotateAngle);
        rotateAngle(targetAngle);

        Vector3 destination = m_transform.position;
        destination.x += 1;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime * m_speed);
    }

    public void moveUp()
    {
        Vector3 destination = m_transform.position;
        destination.z += 1;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime * m_speed);
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void moveDown()
    {
        Vector3 destination = m_transform.position;
        destination.z -= 1;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime * m_speed);
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void moveNone()
    {
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void moveTo(Vector3 destination)
    {
        m_transform.position = Vector3.MoveTowards(m_transform.position, destination, Time.deltaTime * m_speed);
    }

    void rotateAngle(Vector3 targetAngle)
    {
        Vector3 currentAngle = m_transform.eulerAngles;
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime)
        );
        m_transform.eulerAngles = currentAngle;
    }
}