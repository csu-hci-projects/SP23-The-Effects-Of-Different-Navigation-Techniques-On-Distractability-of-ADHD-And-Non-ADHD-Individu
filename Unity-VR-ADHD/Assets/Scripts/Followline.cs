using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Followline : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform goal;
    public LineRenderer line;
    public float heightOffset = 0.5f;

    void Start()
    {
        line.positionCount = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position; 
    }

    void Update()
    {
        if (agent.hasPath)
        {
            Vector3[] smoothedPath = SmoothPath(agent.path.corners);
            line.positionCount = smoothedPath.Length;
            for (int i = 0; i < smoothedPath.Length; i++)
            {
                line.SetPosition(i, smoothedPath[i] + Vector3.up * heightOffset);
            }
        }
        else
        {
            line.positionCount = 0;
        }
    }

    Vector3[] SmoothPath(Vector3[] path)
{
    List<Vector3> smoothedPath = new List<Vector3>();
    smoothedPath.Add(path[0]);
    for (int i = 1; i < path.Length; i++)
    {
        Vector3 direction = (path[i] - path[i - 1]).normalized;
        float distance = Vector3.Distance(path[i - 1], path[i]);
        int steps = Mathf.CeilToInt(distance / 0.1f);
        float stepSize = distance / steps;
        for (int j = 1; j < steps; j++)
        {
            Vector3 point = path[i - 1] + (direction * j * stepSize);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(point, out hit, 0.1f, NavMesh.AllAreas))
            {
                point = hit.position + Vector3.up * 0.1f;
            }
            smoothedPath.Add(point);
        }
        smoothedPath.Add(path[i]);
    }
    return smoothedPath.ToArray();
}
}
