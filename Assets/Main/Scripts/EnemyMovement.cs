using UnityEngine;
using System.Collections.Generic;
using Direction = Enums.Direction;

class EnemyMovement : MovementBehavior
{
    private WayPoints m_waypoints = new WayPoints();
    private List<Vector3> m_destinations = new List<Vector3>();
    private Vector3 objpos;
    private float distance;
    private int m_index;

    public EnemyMovement(IMoveable moveable, WayPoints waypoints) : base(moveable)
    {
        horizontalState = Direction.none;
        verticalState = Direction.none;
        m_moveable = moveable;
        m_waypoints = waypoints;
        m_index = 0;
    }

    public override void applyMovement()
    {
        m_destinations = m_waypoints.getWayPoints();
        objpos = m_moveable.getTransform().position;

        distance = Vector3.Distance(objpos, m_destinations[m_index]);
        if (distance <= 0.25f && m_index < m_destinations.Count-1)
        {
            m_index++;
        }
        else
        {
            m_moveable.moveTo(m_destinations[m_index]);
        }
    }
}
