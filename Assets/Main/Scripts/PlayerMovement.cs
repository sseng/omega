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

    public override void applyMovement()
    {
        Vector3 objpos = m_moveable.getTransform().position;
        if (objpos.x > Borders.left && horizontalState == Direction.left)
            m_moveable.moveLeft();

        if (objpos.x < Borders.right && horizontalState == Direction.right)
            m_moveable.moveRight();

        if (objpos.z < Borders.top && verticalState == Direction.up)
            m_moveable.moveUp();

        if (objpos.z > Borders.bottom && verticalState == Direction.down)
            m_moveable.moveDown();

        if (horizontalState == Direction.none && verticalState == Direction.none)
            m_moveable.moveNone();
    }
}

