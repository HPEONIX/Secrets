using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cantrollers;

public class EnemyFov : MonoBehaviour
{

    [Range(0, 180)]
    public float FovAngle;
    public float FovDistance;

    public LayerMask enemyMask;
    public LayerMask worldMask;

    public Vector3 DirFromAngle(float angleInDeg, bool isGlobel)
    {
        if (!isGlobel)
        {
            angleInDeg += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, FovDistance);
        Vector3 viAngle = DirFromAngle(-FovAngle / 2, false);
        Vector3 viangle2 = DirFromAngle(FovAngle / 2, false);
        Gizmos.DrawLine(transform.position, transform.position + viAngle * FovDistance);
        Gizmos.DrawLine(transform.position, transform.position + viangle2 * FovDistance);
    }
    public bool FindEnemies()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, FovDistance, enemyMask);
        foreach (var enemy in targets)
        {
            var enemytransform = enemy.transform;
            var enemyFov = GetComponent<EnemyFov>();
            var direction = ( enemytransform.position - transform.position).normalized;
            if (Vector3.Angle(enemytransform.forward, direction) < enemyFov.FovAngle / 2)
            {
                if (!Physics.Raycast(transform.position, direction, Vector3.Distance(enemytransform.position, transform.position), enemyFov.worldMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
