using UnityEngine;
using System.Collections.Generic;

public class WayPoints
{
    private Vector3 m_startPoint;
    private List<Vector3> m_waypoints = new List<Vector3>();
    private int m_size;

    public WayPoints()
    {
        m_size = 0;
    }

    public WayPoints(Vector3 spawnPoint, Vector3 destination)
    {
        m_startPoint = spawnPoint;
        m_waypoints.Add(destination);
        m_size++;
    }

    public void setStartPoint(Vector3 location)
    {
        m_startPoint = location;
    }


    public Vector3 getStartPoint()
    {
        return m_startPoint;
    }

    public void addWayPoint(Vector3 location)
    {
        m_waypoints.Add(location);
        m_size++;
    }

    public List<Vector3> getWayPoints()
    {
        return m_waypoints;
    }
}