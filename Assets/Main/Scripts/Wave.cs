using UnityEngine;
using System.Collections.Generic;

class Wave
{
    private int m_count;
    private float m_timer;
    private float m_timePerSpawn;
    private float m_moveSpeed;
    private WayPoints m_wp;
    private GameObject m_unit;
    private Vector3 m_target;

    public Wave(GameObject unitType, int count, float timePerSpawn, WayPoints waypoints)
    {
        m_unit = unitType;
        m_count = count;
        m_timePerSpawn = timePerSpawn;
        m_wp = waypoints;
        m_moveSpeed = 1;
    }

    public Wave(GameObject unitType, int count, float timePerSpawn, WayPoints waypoints, float moveSpeed)
    {
        m_unit = unitType;
        m_count = count;
        m_timePerSpawn = timePerSpawn;
        m_wp = waypoints;
        m_moveSpeed = moveSpeed;
    }

    public void spawn(List<GameObject> unitList)
    {
        m_timer += Time.deltaTime;
        if (m_timer > m_timePerSpawn && m_count > 0)
        {
            GameObject unit = spawnUnit(m_unit, m_wp.getStartPoint()) as GameObject;
            Enemy enemyscript = unit.GetComponent<Enemy>();
            enemyscript.setMovePoints(m_wp);
            if (m_moveSpeed != 1)
                enemyscript.setMoveSpeed(m_moveSpeed);

            unitList.Add(unit);
            m_count--;
            m_timer = 0;
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    GameObject spawnUnit(GameObject enemyType, Vector3 pos)
    {
        return GameObject.Instantiate(enemyType, pos, enemyType.transform.rotation) as GameObject;
    }
}
