using UnityEngine;
using System.Collections;

using Direction = Enums.Direction;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Vehicle m_player;
    private MovementBehavior m_move;
    private GameObject m_bullet;
    private ActionBehavior m_attack1;

    void Start()
    {
        m_player = new Vehicle(100, 10, gameObject.transform);
        m_move = new PlayerMovement(m_player);
        m_bullet = Resources.Load("bullet") as GameObject;
        m_attack1 = new ActionBehavior(m_player, m_bullet, 0.25f);
    }

    void Update()
    {
		m_move.ApplyMovement();
        m_attack1.ActionTimer();
		
		if (Input.GetKey(KeyCode.A))
        {
            m_move.horizontalState = Direction.left;
        }
		else if (Input.GetKey(KeyCode.D))
		{
			m_move.horizontalState = Direction.right;
		}
		else
		{
			m_move.horizontalState = Direction.none;
		}
		
		if (Input.GetKey(KeyCode.W))
		{
			m_move.verticalState = Direction.up;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			m_move.verticalState = Direction.down;
		}		
		else 
		{
			m_move.verticalState = Direction.none;
		}
		
        if (Input.GetKey(KeyCode.Space))
        {
            m_attack1.PerformAction();
        }
    }
}