using UnityEngine;
using System.Collections;

using Direction = Enums.Direction;

public class PlayerCraft : MonoBehaviour, IDamageable
{
    private Vehicle m_vehicle;
    private PlayerMovement m_move;
    private MovementBehavior m_bulletMovement;
    private GameObject m_bullet;
    private ActionBehavior m_attack1;

    void Start()
    {
        m_vehicle = new Vehicle(100, 10, gameObject.transform);
        m_move = new PlayerMovement(m_vehicle);
        m_bullet = Resources.Load("bullet") as GameObject;
        Vector3 bulletDirection = new Vector3(0, 0, Time.deltaTime * 10);
        m_attack1 = new ActionBehavior(m_vehicle, m_bullet, 0.25f, 10f, bulletDirection, "Enemy");
    }

    void Update()
    {
		m_move.applyMovement();
        m_attack1.actionTimer();
		
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
            m_attack1.performAction();
        }

        if (m_vehicle.GetHp() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(float amount)
    {
        m_vehicle.takeDamage(amount);
    }
}