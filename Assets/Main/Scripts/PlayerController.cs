using UnityEngine;
using System.Collections;

using Direction = Enums.Direction;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Borders m_border;
    private Vehicle m_vehicle;
    private MovementBehavior m_move;
    private GameObject m_bullet;
    private ActionBehavior m_attack1;

    void Start()
    {
        m_vehicle = new Vehicle();
        m_vehicle.transform = this.gameObject.transform;
        m_border = new Borders(-13.5f, 13.5f, 8.2f, -8.2f);
        m_move = new MovementBehavior(m_vehicle, speed, m_border);

        m_bullet = Resources.Load("bullet") as GameObject;
        m_attack1 = new ActionBehavior(m_vehicle, m_bullet, 0.25f);
    }

    void Update()
    {
		m_move.ApplyMovement();
        m_attack1.ActionTimer();
		
		if (Input.GetKey(KeyCode.A))
        {
            m_move.horizontalMovement = Direction.left;
        }
		else if (Input.GetKey(KeyCode.D))
		{
			m_move.horizontalMovement = Direction.right;
		}
		else
		{
			m_move.horizontalMovement = Direction.none;
		}
		
		if (Input.GetKey(KeyCode.W))
		{
			m_move.verticalMovement = Direction.up;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			m_move.verticalMovement = Direction.down;
		}		
		else 
		{
			m_move.verticalMovement = Direction.none;
		}
		
        if (Input.GetKey(KeyCode.Space))
        {
            m_attack1.Attack();
        }
    }
}