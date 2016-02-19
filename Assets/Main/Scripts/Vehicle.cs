using UnityEngine;

public class Vehicle : IDamageable, IActor, IMoveable
{
    private float m_speed;
    private float m_hp;
    private float m_attackDamage;
    private Transform m_transform;

    public Vehicle(float hp, float speed, Transform transform)
    {
        m_hp = hp;
        m_speed = speed;
        m_transform = transform;
    }

    public void TakeDamage(float amount)
    {
        m_hp -= amount;
    }

    public void AttackDamage(float damage)
    {
        m_attackDamage = damage;
    }

    public Transform GetTransform()
    {
        return m_transform;
    }

    public void MoveLeft()
    {
        Vector3 targetAngle = new Vector3(0, 0, 60f);
        RotateAngle(targetAngle);

        Vector3 destination = m_transform.position;
        destination.x -= m_speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void MoveRight()
    {
        Vector3 targetAngle = new Vector3(0, 0, -60f);
        RotateAngle(targetAngle);

        Vector3 destination = m_transform.position;
        destination.x += m_speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
    }

    public void MoveUp()
    {
        Vector3 destination = m_transform.position;
        destination.z += m_speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void MoveDown()
    {
        Vector3 destination = m_transform.position;
        destination.z -= m_speed;
        m_transform.position = Vector3.Lerp(m_transform.position, destination, Time.deltaTime);
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void MoveNone()
    {
        m_transform.rotation = Quaternion.Lerp(m_transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    void RotateAngle(Vector3 targetAngle)
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