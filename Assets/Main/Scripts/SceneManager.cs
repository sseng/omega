using UnityEngine;
using System.Collections.Generic;

class SceneManager : MonoBehaviour
{
    public int startingLives = 4;
    public int score; 
    private Player p1;
    private GameObject playerCraft;
    private GameObject EnemyType1;
    private Vector3 topLeftSpawn = new Vector3(Borders.left - 2, 0, Borders.top + 1);
    private Vector3 topLeftSpawn2 = new Vector3(Borders.left + 2, 0, Borders.top + 1);
    private Vector3 bottomLeftSpawn2 = new Vector3(Borders.left + 2, 0, Borders.bottom - 3);
    private Vector3 topRight1 = new Vector3(Borders.right - 2, 0, Borders.top + 3);
    private Vector3 botRight1 = new Vector3(Borders.right - 2, 0, Borders.bottom - 3);
    private WayPoints m_topLeftToBottomRight;
    private WayPoints m_rightVertical;
    private Wave m_wave1;
    private Wave m_wave2;
    private List<GameObject> m_enemies = new List<GameObject>();

    void Start()
    {
        playerCraft = Resources.Load("omega_fighter") as GameObject;
        p1 = new Player(playerCraft, startingLives);
        p1.spawn();

        EnemyType1 = Resources.Load("Enemy1") as GameObject;

        m_topLeftToBottomRight = new WayPoints(topLeftSpawn, Borders.bottomRight);
        m_rightVertical = new WayPoints(topRight1, botRight1);
        m_topLeftToBottomRight.addWayPoint(topRight1);
        m_wave1 = new Wave(EnemyType1, 4, 2, m_rightVertical, 0.75f);
        m_wave2 = new Wave(EnemyType1, 6, 1, m_topLeftToBottomRight);
    }

    void Update()
    {
        score = p1.Score;
        playerRespawns(p1);

        m_wave1.spawn(m_enemies);
        m_wave2.spawn(m_enemies);
        checkEnemy(m_enemies);
        setTarget(m_enemies, p1.getPosition());
    }

    void playerRespawns(Player player)
    {
        if (player.hasLives() && !player.isAlive())
        {
            player.spawn();
        }
    }

    void setTarget(List<GameObject> units, Vector3 target)
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].GetComponent<Enemy>().setProjectileDirection(target);
        }
    }

    void checkEnemy(List<GameObject> units)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].GetComponent<Enemy>().isDead())
            {
                p1.Score += 10;
                units[i].gameObject.SetActive(false);
            }
        }
    }
}