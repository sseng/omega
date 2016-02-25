using UnityEngine;
using System.Collections;

class SceneManager : MonoBehaviour
{
    public int startingLives = 4;
    private Player p1;
    private GameObject playerCraft;
    private GameObject EnemyType1;
    //private List<GameObject> m_enemies = new List<GameObject>();
    private float timer;
    private float enemyCount;
    private Vector3 topLeftSpawn = new Vector3(Borders.left - 2, 0, Borders.top + 1);
    private Vector3 topLeftSpawn2 = new Vector3(Borders.left + 2, 0, Borders.top + 1);
    private Vector3 bottomLeftSpawn2 = new Vector3(Borders.left + 2, 0, Borders.bottom - 3);
    private Vector3 topRight1 = new Vector3(Borders.right - 2, 0, Borders.top + 3);
    private Vector3 botRight1 = new Vector3(Borders.right - 2, 0, Borders.bottom - 3);
    private WayPoints m_topLeftToBottomRight;
    private WayPoints m_rightVertical;
    private Wave wave1;
    private Wave wave2;

    void Start()
    {
        playerCraft = Resources.Load("omega_fighter") as GameObject;
        p1 = new Player(playerCraft, startingLives);
        p1.spawn();

        EnemyType1 = Resources.Load("Enemy1") as GameObject;

        m_topLeftToBottomRight = new WayPoints(topLeftSpawn, Borders.bottomRight);
        m_rightVertical = new WayPoints(topRight1, botRight1);
        m_topLeftToBottomRight.addWayPoint(topRight1);

        wave1 = new Wave(EnemyType1, 4, 0.75f, m_rightVertical);
        wave2 = new Wave(EnemyType1, 6, 1, m_topLeftToBottomRight);
    }

    void Update()
    {
        if (p1.hasLives() && !p1.isAlive())
        {
            p1.spawn();
        }
        wave1.spawn();
        wave2.spawn();
    }
}