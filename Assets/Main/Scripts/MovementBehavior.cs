using UnityEngine;
using Direction = Enums.Direction;

public class MovementBehavior 
{
	public Direction horizontalState;
	public Direction verticalState;

    protected IMoveable m_moveable;

    public MovementBehavior(IMoveable moveable)
    {
        horizontalState = Direction.none;
        verticalState = Direction.none;
        m_moveable = moveable;
    }

    public virtual void applyMovement()
    {
        if (horizontalState == Direction.left)
            m_moveable.moveLeft();

        if (horizontalState == Direction.right)
            m_moveable.moveRight();

        if (verticalState == Direction.up)
            m_moveable.moveUp();

        if (verticalState == Direction.down)
            m_moveable.moveDown();

        if (verticalState == Direction.none)
            m_moveable.moveNone();
	}
}