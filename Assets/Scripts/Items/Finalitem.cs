using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalitem : MonoBehaviour
{
    public GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            //trigger end
            Destroy(gameObject);
        }
    }
}
