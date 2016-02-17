using UnityEngine;
using System.Collections;

using Direction = Enums.Direction;

public class PlayerController : MonoBehaviour {
    public float speed = 2;
    public float rotationSpeed = 1f;

    private Borders m_field;
    private GameObject m_player;
    private Movement m_move;
    private Direction m_horizontal, m_vertical;

	void Start() {
        m_field = new Borders(-13.5f, 13.5f, 8f, -8f);
        m_player = this.gameObject;
        m_move = new Movement();
	}
	
	void Update() {
        m_horizontal = m_move.HorizontalMovement(m_player, m_field);
        m_vertical = m_move.VerticalMovement(m_player, m_field);
        if (m_horizontal == Direction.left)
        {
            MoveLeft();
        }

        if (m_horizontal == Direction.right)
        {
            MoveRight();
        }

        if (m_vertical == Direction.up)
        {
            MoveUp();
        }

        if (m_vertical == Direction.down)
        {
            MoveDown();
        }
        else
        {
            MoveNone();
        }
	}

    void MoveLeft()
    {
        Vector3 targetAngle = new Vector3(0,0,60f);
        RotateAngle(targetAngle);
        this.transform.position += new Vector3(-speed / 10, 0f, 0f);
    }

    void MoveRight()
    {
        Vector3 targetAngle = new Vector3(0, 0, -60f);
        RotateAngle(targetAngle);
        this.transform.position += new Vector3(speed / 10, 0f, 0f);
    }

    void MoveUp()
    {
        this.transform.position += new Vector3(0, 0, speed / 10);
    }

    void MoveDown()
    {
        this.transform.position += new Vector3(0, 0, -speed / 10);
    }

    void MoveNone()
    {
        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * rotationSpeed);
    }

    void RotateAngle(Vector3 targetAngle)
    {
        Vector3 currentAngle = transform.eulerAngles;
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * rotationSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * rotationSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * rotationSpeed)
        );
        this.transform.eulerAngles = currentAngle;
    }
}
