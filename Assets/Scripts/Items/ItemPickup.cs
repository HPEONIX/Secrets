using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            var tmp = transform.parent.GetComponent<ItemManager>();
            if (tmp != null) tmp.openDoor();
            Destroy(gameObject);
        }
    }
}
