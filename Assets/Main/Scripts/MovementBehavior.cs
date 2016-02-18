using UnityEngine;

using Direction = Enums.Direction;

public class MovementBehavior 
{
	public Direction horizontalMovement;
	public Direction verticalMovement;
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
        horizontalMovement = Direction.none;
        verticalMovement = Direction.none;
    }
    
    public void ApplyMovement()
    {
        Vector3 objpos = m_vehicle.transform.position;
        if (objpos.x > m_border.GetLeftBorder() && horizontalMovement == Direction.left)
            MoveLeft();

        if (objpos.x < m_border.GetRightBorder() && horizontalMovement == Direction.right)
            MoveRight();

        if (objpos.z < m_border.GetTopBorder() && verticalMovement == Direction.up)
            MoveUp();

        if (objpos.z > m_border.GetBottomBorder() && verticalMovement == Direction.down)
            MoveDown();

        if (horizontalMovement == Direction.none && verticalMovement == Direction.none)
                MoveNone();
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
        m_vehicle.transform.rotation = Quaternion.Lerp(m_vehicle.transform.rotation, Quaternion.identity, Time.deltaTime);
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