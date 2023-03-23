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
            //Make it also go up and down the line
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
            
        }
        else
        {
            line.positionCount = 0;
        }
    }
}