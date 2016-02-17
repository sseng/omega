using UnityEngine;

using Direction = Enums.Direction;

public class MovementBehavior 
{
    private float m_speed;
    private Vehicle m_vehicle;
    private Borders m_border;

    //ctor
    public MovementBehavior()
    {
        m_speed = 10;
        m_vehicle = new Vehicle();
        m_border = new Borders();
    }

    public MovementBehavior(Vehicle vehicle, float speed, Borders border)
    {
        m_vehicle = vehicle;
        m_speed = speed;
        m_border = border;
    }

	public Direction VerticalMovement() 
    {
        Vector3 objpos = m_vehicle.transform.position;
        if (Input.GetKey(KeyCode.S) && objpos.z > m_border.GetBottomBorder())
        {
            return Direction.down;
        }

        if (Input.GetKey(KeyCode.W) && objpos.z < m_border.GetTopBorder())
        {
            return Direction.up;
        }
        return Direction.none;
	}

    public Direction HorizontalMovement()
    {
        Vector3 objpos = m_vehicle.transform.position;
        if (Input.GetKey(KeyCode.A) && objpos.x > m_border.GetLeftBorder())
        {
            return Direction.left;
        }

        if (Input.GetKey(KeyCode.D) && objpos.x < m_border.GetRightBorder())
        {
            return Direction.right;
        }
        return Direction.none;
    }

    public void MoveLeft()
    {
        Vector3 targetAngle = new Vector3(0, 0, 60f);
        RotateAngle(targetAngle);

        Vector3 destination = m_vehicle.transform.position;
        destination.x -= m_speed;
        m_vehicle.transform.position = Vector3.Lerp(m_vehicle.transform.position, destination, Time.deltaTime);
    }

    public void MoveRight()
    {
        Vector3 targetAngle = new Vector3(0, 0, -60f);
        RotateAngle(targetAngle);

        Vector3 destination = m_vehicle.transform.position;
        destination.x += m_speed;
        m_vehicle.transform.position = Vector3.Lerp(m_vehicle.transform.position, destination, Time.deltaTime);
    }

    public void MoveUp()
    {
        Vector3 destination = m_vehicle.transform.position;
        destination.z += m_speed;
        m_vehicle.transform.position = Vector3.Lerp(m_vehicle.transform.position, destination, Time.deltaTime);
    }

    public void MoveDown()
    {
        Vector3 destination = m_vehicle.transform.position;
        destination.z -= m_speed;
        m_vehicle.transform.position = Vector3.Lerp(m_vehicle.transform.position, destination, Time.deltaTime);
        m_vehicle.transform.rotation = Quaternion.Lerp(m_vehicle.transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    public void MoveNone()
    {
        m_vehicle.transform.rotation = Quaternion.Lerp(m_vehicle.transform.rotation, Quaternion.identity, Time.deltaTime);
    }

    void RotateAngle(Vector3 targetAngle)
    {
        Vector3 currentAngle = m_vehicle.transform.eulerAngles;
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime)
        );
        m_vehicle.transform.eulerAngles = currentAngle;
    }
}