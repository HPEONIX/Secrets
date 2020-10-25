using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 5f;
    public float speed = 10f;
    // Start is called before the first frame update
    private void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward*speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        var status = other.GetComponent<Status>();
        if(status!=null)
        {
            status.takeDmg(Damage);
        }
        Destroy(gameObject);
    }
}
