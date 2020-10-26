using System.Collections;
using System.Collections.Generic;
using Cantrollers;
using UnityEngine;

public class Finalitem : MonoBehaviour
{
    public GameObject particle;
    public GameObject thanks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            //trigger end
            thanks.SetActive(true);
            foreach (var tmp in GameObject.FindObjectsOfType<EnemyCantroler>())
            {
                var stat=tmp.GetComponent<Status>();
                stat.takeDmg(stat.health);
            }
            Destroy(gameObject);
        }
    }
}
