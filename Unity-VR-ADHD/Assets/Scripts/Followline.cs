using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Followline : MonoBehaviour
{
//Make a unity script that takes a navemesh agent and a line render and renders the navmesh line
//Make it also folliw up and down the line



    public NavMeshAgent agent;
    public Transform goal;
    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 0;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position; 
    }

    // Update is called once per frame
    void Update()
{
    if(agent.hasPath)
    {
        Vector3[] smoothedPath = SmoothPath(agent.path.corners);
        line.positionCount = smoothedPath.Length;
        line.SetPositions(smoothedPath);
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
        Vector3 direction = (path[i] - path[i-1]).normalized;
        float distance = Vector3.Distance(path[i-1], path[i]);
        int steps = Mathf.CeilToInt(distance / 0.1f); // Increase or decrease the step size to adjust smoothing
        float stepSize = distance / steps;
        for (int j = 1; j < steps; j++)
        {
            Vector3 point = path[i-1] + (direction * j * stepSize);
            RaycastHit hit;
            if (Physics.Raycast(point + Vector3.up * 10f, Vector3.down, out hit, 20f, NavMesh.AllAreas))
            {
                point = hit.point + Vector3.up * 0.1f; // Increase or decrease the height offset to adjust line position
            }
            smoothedPath.Add(point);
        }
        smoothedPath.Add(path[i]);
    }
    return smoothedPath.ToArray();
}
}