using UnityEngine;

class Wave
{
    private WayPoints m_wp;
    private GameObject m_unit;
    private int m_count;
    private float m_timer;
    private float m_timePerSpawn;

    public Wave(GameObject unitType, int count, float timePerSpawn, WayPoints waypoints)
    {
        m_unit = unitType;
        m_count = count;
        m_timePerSpawn = timePerSpawn;
        m_wp = waypoints;
    }

    public void spawn()
    {
        m_timer += Time.deltaTime;
        if (m_timer > m_timePerSpawn && m_count > 0)
        {
            GameObject e = spawnEnemy(m_unit, m_wp.getStartPoint()) as GameObject;
            Enemy enemyscript = e.GetComponent<Enemy>();
            enemyscript.setMovePoints(m_wp);
            m_count--;
            m_timer = 0;
        }
    }

    GameObject spawnEnemy(GameObject enemyType, Vector3 pos)
    {
        return GameObject.Instantiate(enemyType, pos, enemyType.transform.rotation) as GameObject;
    }
}
