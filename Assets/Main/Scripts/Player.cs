using UnityEngine;

class Player
{
    private int m_lives;
    private GameObject m_gobj;
    private GameObject m_playerCraft;

    public Player(GameObject gobj, int lives)
    {
        m_gobj = gobj;
        m_lives = lives;
    }

    public void spawn()
    {
        m_playerCraft = GameObject.Instantiate(m_gobj);
        m_lives--;
    }

    public bool isAlive()
    {
        if (m_playerCraft != null)
            return true;
        return false;
    }

    public bool hasLives()
    {
        return m_lives > 0;
    }
}

