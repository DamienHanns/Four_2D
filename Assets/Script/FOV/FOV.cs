﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour {
    
    [SerializeField] public float viewRadius;
    [SerializeField] [Range(0.0f, 360.0f)] public float viewAngle;

    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obsticleMask;

    public List<Transform> visableTagets = new List<Transform>();
    public bool bIsTargetInLOS;

    private void Start()
    {
        StartCoroutine(CheckForTargets());
    }

    IEnumerator CheckForTargets()
    {
        float checkRefreshTimer = 0.2f;
        while (true)
        {
            FindVisableTargets();
            yield return new WaitForSeconds(checkRefreshTimer);
        }
    }

    void FindVisableTargets()
    {
        bIsTargetInLOS = false;
        visableTagets.Clear();

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; ++i)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float disToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obsticleMask))
                {
                    visableTagets.Add(target);
                    bIsTargetInLOS = true;
                }
            }
        }
    }

    internal Vector3 DirFromAngle(float angleInDegrees, bool bIsAngleGlobal)
    {
        if (!bIsAngleGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0.0f);
    }
}
