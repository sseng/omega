using UnityEngine;
using System.Collections;

using Direction = Enums.Direction;

public class Movement 
{
    public Movement(){}

	public Direction VerticalMovement(GameObject obj, Borders field) 
    {
        Vector3 objpos = obj.transform.position;
        if (Input.GetKey(KeyCode.S) && objpos.z > field.GetBottomBorder())
        {
            return Direction.down;
        }

        if (Input.GetKey(KeyCode.W) && objpos.z < field.GetTopBorder())
        {
            return Direction.up;
        }
        return Direction.none;
	}

    public Direction HorizontalMovement(GameObject obj, Borders field)
    {
        Vector3 objpos = obj.transform.position;
        if (Input.GetKey(KeyCode.A) && objpos.x > field.GetLeftBorder())
        {
            return Direction.left;
        }

        if (Input.GetKey(KeyCode.D) && objpos.x < field.GetRightBorder())
        {
            return Direction.right;
        }
        return Direction.none;
    }
}
