using UnityEngine;
using System.Collections;

public class Borders  {

    private float _leftBorder, _rightBorder, _topBorder, _bottomBorder;

    public Borders()
    {
        _leftBorder = -10.0f;
        _rightBorder = 10.0f;
        _bottomBorder = -8.0f;
        _topBorder = 8.0f;
    }

    public Borders(float left, float right, float top, float bottom)
    {
        _leftBorder = left;
        _rightBorder = right;
        _topBorder = top;
        _bottomBorder = bottom;
    }

    public float GetLeftBorder()
    {
        return _leftBorder;
    }

    public float GetRightBorder()
    {
        return _rightBorder;
    }

    public float GetTopBorder()
    {
        return _topBorder;
    }

    public float GetBottomBorder()
    {
        return _bottomBorder;
    }
}
