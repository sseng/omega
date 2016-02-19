using UnityEngine;


class Bullet1 : Projectile
{
    public Bullet1(GameObject gobj, float speed)
    {
        m_transform = gobj.transform;
        m_speed = speed;
    }
}

