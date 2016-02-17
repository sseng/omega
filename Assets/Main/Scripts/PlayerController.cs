using UnityEngine;
using System.Collections;

using Direction = Enums.Direction;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Borders m_border;
    private Vehicle m_vehicle;
    private GameObject m_vehicleObj;
    private MovementBehavior m_move;
    private Direction horizontalMovement;
    private Direction verticalMovement;

    private GameObject m_bullet;
    private ActionBehavior m_defaultAction;

    void Start()
    {
        m_vehicleObj = this.gameObject;
        m_vehicle = new Vehicle(m_vehicleObj);
        m_border = new Borders(-13.5f, 13.5f, 8f, -8f);
        m_move = new MovementBehavior(m_vehicle, speed, m_border);

        m_bullet = Resources.Load("bullet") as GameObject;
        m_defaultAction = new ActionBehavior(m_vehicle, m_bullet, 1.5f, 0.25f);
    }

    void Update()
    {
        horizontalMovement = m_move.HorizontalMovement();
        verticalMovement = m_move.VerticalMovement();
        if (horizontalMovement == Direction.left)
        {
            m_move.MoveLeft();
        }

        if (horizontalMovement == Direction.right)
        {
            m_move.MoveRight();
        }

        if (verticalMovement == Direction.up)
        {
            m_move.MoveUp();
        }

        if (verticalMovement == Direction.down)
        {
            m_move.MoveDown();
        }
        m_move.MoveNone();

        if (Input.GetKey(KeyCode.Space))
        {
            m_defaultAction.Attack();
        }
    }
}