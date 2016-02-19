using UnityEngine;
using Direction = Enums.Direction;

class PlayerMovement : MovementBehavior
{
    public PlayerMovement(IMoveable moveable) : base(moveable)
    {
        horizontalState = Direction.none;
        verticalState = Direction.none;
        m_moveable = moveable;
    }

    public override void ApplyMovement()
    {
        Vector3 objpos = m_moveable.GetTransform().position;
        if (objpos.x > Borders.GetLeftBorder() && horizontalState == Direction.left)
            m_moveable.MoveLeft();

        if (objpos.x < Borders.GetRightBorder() && horizontalState == Direction.right)
            m_moveable.MoveRight();

        if (objpos.z < Borders.GetTopBorder() && verticalState == Direction.up)
            m_moveable.MoveUp();

        if (objpos.z > Borders.GetBottomBorder() && verticalState == Direction.down)
            m_moveable.MoveDown();

        if (horizontalState == Direction.none && verticalState == Direction.none)
            m_moveable.MoveNone();
    }
}

