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

    public virtual void ApplyMovement()
    {
        if (horizontalState == Direction.left)
            m_moveable.MoveLeft();

        if (horizontalState == Direction.right)
            m_moveable.MoveRight();

        if (verticalState == Direction.up)
            m_moveable.MoveUp();

        if (verticalState == Direction.down)
            m_moveable.MoveDown();

        if (verticalState == Direction.none)
            m_moveable.MoveNone();
	}
}