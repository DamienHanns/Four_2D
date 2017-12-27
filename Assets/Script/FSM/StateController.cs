using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public event System.Action OnExitState;     //TODO get rid of this

    public Stats entityStats;
    public State currentState;
    public State remainInState;
    public Transform stateIndicatorHolder;

    [HideInInspector] public Rigidbody2D myrb;
    [HideInInspector] public PolyNavAgent agent;
    [HideInInspector] public Vector3[] waypoints;
    [HideInInspector] public int nextWaypointIndex = 0;
    public bool bIsCyclicalPath;
    public bool bHasPath;
    public bool bIsAttacking;
    public Transform waypointHolder;

    public float stateTimeElapsed;

    [HideInInspector] public FOV fov;
    public Transform priorityOOI;
    bool bStateControllerActive;

    private void Start()
    {
        myrb = GetComponent<Rigidbody2D>() ? GetComponent<Rigidbody2D>() : null;
        agent = GetComponent<PolyNavAgent>() ? GetComponent<PolyNavAgent>() : null;
        fov = GetComponent<FOV>() ? GetComponent<FOV>() : null;
        if (waypointHolder != null) { GetWaypoints(); }
    }

    void Update () {
        if (bStateControllerActive) { return; }
        currentState.ExecuteState(this);
        Debug.Log(currentState);
	}

    public void SetupStateController(bool bActivateStateController, Transform _waypointHolder)
    {
        bStateControllerActive = bActivateStateController;
        waypointHolder = _waypointHolder;
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainInState)
        {
            ExitState();
            currentState = nextState;
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed > duration);
    }

    void ExitState()
    {
        if (OnExitState != null)
        {
            OnExitState();
        }

        bHasPath = false;
        StopAllCoroutines();        //TODO check if stopping coroutines is nessesary
        stateTimeElapsed = 0.0f;
        agent.Stop();
    }

    void GetWaypoints()
    {
        waypoints = new Vector3[waypointHolder.childCount];
        for (int i = 0; i < waypoints.Length; ++i)
        {
            waypoints[i] = waypointHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, waypoints[i].y, waypoints[i].z);
        }

        if (nextWaypointIndex >= waypoints.Length) { nextWaypointIndex = 0; }
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
