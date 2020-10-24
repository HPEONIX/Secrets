using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{

    public float health=20f;
    public bool isDead =false;


    public void takeDmg(float dmg)
    {
        health -= dmg;
        if (!isDead && health <= 0)
            die();

    }

    private void die()
    {
        isDead = true;
        Debug.Log("dead");
        GetComponent<StateManager>().stopAllActions();
    }
}
