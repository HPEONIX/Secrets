using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{

    [Range(0, 180)]
    public float FovAngle;
    public float FovDistance;

    public LayerMask enemyMask;
    public LayerMask worldMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
