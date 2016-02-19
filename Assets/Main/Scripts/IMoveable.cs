using UnityEngine;

public interface IMoveable
{
    void MoveLeft();
    void MoveRight();
    void MoveUp();
    void MoveDown();
    void MoveNone();
    Transform GetTransform();
}
