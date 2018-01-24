using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {          //TODO use statecontoller as base class?

    public delegate void OnExitState();     
    public event OnExitState onExitState;

#region States data
    public EntityStats entityStats;
    public State currentState;
    public State remainInState;
    public ReactionStates reactionStates; 
    public Transform stateIndicatorHolder;
    #endregion

#region pathfinding / waypoints data
    [HideInInspector] public PolyNavAgent agent;
    [HideInInspector] public Vector3[] waypoints;
    [HideInInspector] public int nextWaypointIndex = 0;
    public bool bIsCyclicalPath;
    [HideInInspector] public bool bHasPath;
    public Transform waypointHolder;
#endregion

    [HideInInspector] public Rigidbody2D myrb;

    public bool bHasStatedAction;
    public bool bPrimaryStateActionFinished;

    [HideInInspector] float stateTimeElapsed;
    [HideInInspector] public FOV fov;
    [HideInInspector] public Transform priorityOOI;

    public bool bStateControllerActive;

    private void Start()
    {
        if (remainInState == null) { Debug.LogWarning(gameObject.name + ": remainInState object not assigned"); }

        myrb = GetComponent<Rigidbody2D>() ? GetComponent<Rigidbody2D>() : null;
        agent = GetComponent<PolyNavAgent>() ? GetComponent<PolyNavAgent>() : null;
        fov = GetComponent<FOV>() ? GetComponent<FOV>() : null;

        if (waypointHolder != null) { GetWaypoints(); }
    }

    void Update () {
        if ( ! bStateControllerActive) { return; }
        currentState.ExecuteState(this);
	}

#region
    public void SetupStateController(bool bActivateStateController, EntityStats objectStats, State state, ReactionStates _reactionStates, Transform _waypointHolder = null, bool bPutWaypointsIntoArray = true)
    {
        bStateControllerActive = bActivateStateController;
        entityStats = objectStats;
        reactionStates = _reactionStates;
        waypointHolder = _waypointHolder;
        if (bPutWaypointsIntoArray) { GetWaypoints(); }

        currentState = state;
        TransitionToState(state);
    }

    public void SetupStateController(Transform _waypointHolder, bool bPutWaypointsIntoArray = true)
    {
        if (_waypointHolder != null)
        {
            waypointHolder = _waypointHolder;
            if (bPutWaypointsIntoArray) GetWaypoints();
        } else { Debug.Log(transform.name + ": could not set up way points, the HOLDER was null"); }
    }

    public void SetupStateController(bool bActivateStateController)
    {
        bStateControllerActive = bActivateStateController;
    }

    public void SetupStateController(EntityStats objectStats, State state, ReactionStates _reactionStates, bool bActivateStateController = true)
    {
        reactionStates = _reactionStates;
        SetupStateController(objectStats, bActivateStateController);
        currentState = state;
        TransitionToState(state);
    }

    public void SetupStateController(EntityStats objectStats,  bool bActivateStateController = true)
    {
        entityStats = objectStats;
        bStateControllerActive = bActivateStateController;
    }
#endregion

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
        if (onExitState != null)
        {
            onExitState();
        }

        ResetControllerVeriables();
        StopAllCoroutines();        
        if (agent != null) { agent.Stop(); }
    }

    private void ResetControllerVeriables()
    {
        onExitState = null;
        bHasPath = false;
        bHasStatedAction = false;
        bPrimaryStateActionFinished = false;
        stateTimeElapsed = 0.0f;
    }

    void GetWaypoints()
    {
        if (waypointHolder != null)
        {
            waypoints = new Vector3[waypointHolder.childCount];
            for (int i = 0; i < waypoints.Length; ++i)
            {
                waypoints[i] = waypointHolder.GetChild(i).position;
                waypoints[i] = new Vector3(waypoints[i].x, waypoints[i].y, waypoints[i].z);
            }
            if (nextWaypointIndex >= waypoints.Length) { nextWaypointIndex = 0; }
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
