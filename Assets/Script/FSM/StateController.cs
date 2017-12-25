using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public State currentState;
    public Transform stateIndicatorHolder;

    [HideInInspector] public FOV fov;
    [HideInInspector] public Vector3[] waypoints;
    [HideInInspector] public int nextWaypointIndex;
    public bool bIsCyclicalPath;
    Transform waypointHolder;

    public Transform priorityOOI;
    bool bStateControllerActive;
    
	void Update () {
        if (bStateControllerActive) { return; }
        currentState.ExecuteState(this);
	}

    public void SetupStateController(bool bActivateStateController, Transform _waypointHolder)
    {
        bStateControllerActive = bActivateStateController;
        waypointHolder = _waypointHolder;
    }

    void GetWaypoints()
    {
        waypoints = new Vector3[waypointHolder.childCount];
        for (int i = 0; i < waypoints.Length; ++i)
        {
            waypoints[i] = waypointHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }
    }

    void OnDrawGizmos()
    {
        if (currentState != null && stateIndicatorHolder != null)
        {
            Gizmos.color = currentState.stateIndicatorColour;
            Gizmos.DrawSphere(stateIndicatorHolder.position, 0.25f);
        }

        if (waypointHolder != null)
        {
            Vector3 startPos = waypointHolder.GetChild(0).position;
            Vector3 privousPos = startPos;

            Gizmos.color = Color.blue;

            foreach (Transform waypoint in waypointHolder)
            {
                Gizmos.DrawSphere(waypoint.position, 0.3f);
                Gizmos.DrawLine(privousPos, waypoint.position);

                privousPos = waypoint.position;
            }

            if (bIsCyclicalPath) { Gizmos.DrawLine(privousPos, startPos); }
        }
    }
}
