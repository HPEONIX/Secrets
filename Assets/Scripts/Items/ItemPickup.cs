using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
