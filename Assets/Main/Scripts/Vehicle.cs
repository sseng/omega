using UnityEngine;

public class Vehicle : IDamageable
{
    public GameObject Gobj
    {
        get;
        set;
    }

    public Transform transform
    {
        get { return Gobj.transform; }
    }

    public float Hp
    {
        get;
        set;
    }

    public float Speed
    {
        get;
        set;
    }
    public Vehicle()
    {
        Hp = 100;
        Speed = 1;
        Gobj = new GameObject();
    }

    public Vehicle(GameObject gobj)
    {
        Gobj = gobj;
    }

    public void TakeDamage(float amount)
    {
        Hp -= amount;
    }
}