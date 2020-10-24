using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Range(0,180)]
    public float FovAngle;
    public float FovDistance;

    public LayerMask enemyMask;

    public void FindEnemies()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, FovDistance, enemyMask);
        foreach(var enemy in targets)
        {
            var enemytransform = enemy.transform;
            var enemyFov = enemytransform.GetComponent<EnemyFov>();
            if (enemyFov == null) continue;
            var direction = (transform.position- enemytransform.position).normalized;
            if(Vector3.Angle(enemytransform.forward,direction)<enemyFov.FovAngle/2)
            {
                if(!Physics.Raycast(enemytransform.position,direction,Vector3.Distance(enemytransform.position,transform.position),enemyFov.worldMask))
                    Debug.Log("stop there");
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDeg,bool isGlobel)
    {
        if(!isGlobel)
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
        Gizmos.DrawLine(transform.position,transform.position + viAngle *FovDistance);
        Gizmos.DrawLine(transform.position,transform.position + viangle2 * FovDistance);
    }
}
