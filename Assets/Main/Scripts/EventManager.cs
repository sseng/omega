using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerAction();
    public static event PlayerAction OnAttack;

    void Update()
    {
        if (OnAttack != null)
        {
            OnAttack();
        }
    }
}

