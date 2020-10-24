using System;
using System.Collections;
using System.Collections.Generic;
using movement;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class Fight : MonoBehaviour, IActions
{

    Status Charstat;
    Status targetstat;
    public float attackDistance;
    public float attackcooldown = 2f;
    public float damage;

    float TimeofLastAttack = 0f;

    public bool canDoDmg = true;

    private void Awake()
    {
        Charstat = GetComponent<Status>();
    }

    private void Update()
    {
        if (Charstat.isDead)
            return;
        if (TimeofLastAttack <= attackcooldown)
        {
            TimeofLastAttack += Time.deltaTime;
        }
        if (targetstat==null || targetstat.isDead == true)
        {
            return;
        }

        if (!InRange())
        {
            GetComponent<Move>().moveTo(targetstat.transform.position,1f);
        }
        else
        {
            GetComponent<Move>().stopAction();
            transform.LookAt(targetstat.transform);
            if (TimeofLastAttack >= attackcooldown && canDoDmg)
            {

                TimeofLastAttack = 0f;
                TriggerAttack();
            }
        }
    }

    private void TriggerAttack()
    {
        Debug.Log("Attack");
        targetstat.takeDmg(damage);
    }

    private bool InRange()
    {
        return Vector3.Distance(transform.position, targetstat.transform.position) < attackDistance;
    }

    public bool canAttack(GameObject target)
    {
        var targetstat = target.GetComponent<Status>();
        if (targetstat && targetstat.isDead == false)
        {
            return true;
        }
        return false;
    }

    internal void attack(GameObject player)
    {
        GetComponent<StateManager>().StartAction(this);
        targetstat = player.GetComponent<Status>();
    }

    public void pauseAction()
    {
        canDoDmg = false;
    }

    public void stopAction()
    {
        GetComponent<Move>().stopAction();
        targetstat = null;
    }
}
