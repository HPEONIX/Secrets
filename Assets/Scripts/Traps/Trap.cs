using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trap:MonoBehaviour
{

    public GameObject projectile_Prefab;
    public float TriggerIntervel;

    public void Activate()
    {
        StartCoroutine("ActivateTrap");
    }

    public void Deactivate()
    {
        StopCoroutine("ActivateTrap");
    }

    IEnumerator ActivateTrap()
    {
        while (true)
        {
            var tmp = Instantiate(projectile_Prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(TriggerIntervel);
        }
    }

}