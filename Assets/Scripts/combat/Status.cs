using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{

    public float health=20f;
    public bool isDead =false;
    public GameObject gameOver;

    public ParticleSystem blood;


    public void takeDmg(float dmg)
    {
        health -= dmg;
        blood.Play();
        if (!isDead && health <= 0)
            die();

    }

    private void die()
    {
        isDead = true;
        if (gameOver != null) gameOver.SetActive(true);
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<StateManager>().stopAllActions();
    }
}
