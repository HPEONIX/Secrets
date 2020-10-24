using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    const float gizmoSpearSize = 0.3f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(transform.GetChild(i).position, gizmoSpearSize);
            Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(GetNextIndex(i)));
        }
    }

    public Vector3 getFirst()
    {
        return GetWayPoint(0);
    }

    public int GetNextIndex(int i)
    {
        return (i + 1 >= transform.childCount) ? 0 : i + 1;
    }

    public Vector3 GetWayPoint(int i)
    {
        return transform.GetChild(i).position;
    }
}
