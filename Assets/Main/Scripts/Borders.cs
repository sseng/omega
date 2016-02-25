using UnityEngine;
using System.Collections;

public static class Borders
{
    public static float left = -16.5f;
    public static float right = 16.5f;
    public static float top = 8.25f;
    public static float bottom = -8.25f;
    public static Vector3 topLeft = new Vector3(left, 0, top);
    public static Vector3 topRight = new Vector3(right, 0, top);
    public static Vector3 bottomLeft = new Vector3(left, 0, bottom);
    public static Vector3 bottomRight = new Vector3(right, 0, bottom);
}
