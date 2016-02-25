using UnityEngine;
using System.Collections.Generic;

public static class ExtensionMethods
{
    public static void applyPattern(this GameObject gobj, List<Vector3> locations)
    {
       for (int i = 1; i < locations.Count; i++)
        {
            gobj.transform.position = Vector3.Lerp(gobj.transform.position, locations[i], Time.deltaTime / 10);
        }
    }
}
