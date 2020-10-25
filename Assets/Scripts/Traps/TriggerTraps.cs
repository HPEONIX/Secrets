using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTraps : MonoBehaviour
{

    public Trap trap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Status>()!=null )
        {
            trap.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Status>() != null)
        {
            trap.Deactivate();
        }
    }

}
