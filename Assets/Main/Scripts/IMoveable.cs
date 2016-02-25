using UnityEngine;

public interface IMoveable
{
    void moveLeft();
    void moveRight();
    void moveUp();
    void moveDown();
    void moveNone();
    void moveTo(Vector3 destination);
    Transform getTransform();
}
