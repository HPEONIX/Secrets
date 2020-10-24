using System;
using System.Collections;
using System.Collections.Generic;
using movement;
using UnityEngine;

namespace Cantrollers
{
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Status))]
    [RequireComponent(typeof(Fight))]
    public class EnemyCantroler : MonoBehaviour
    {
        public PatrolPath patrolPath;
        GameObject player;
        private Status CharStat;
        Transform plaerlocation;
        Fight fight;
        EnemyFov fov;
        private float lastSightTime = Mathf.Infinity;
        public float maxSusTime = 2f;
        private float timeSinceArrivedAtWayPoint = Mathf.Infinity;

        public float WaypointDwellTime=2f;
        private Vector3 guardPose;
        private int currentWaypointIndex =0;

        public float WaypointDelta = 1f;

        private void Awake()
        {
            CharStat = GetComponent<Status>();
            fight = GetComponent<Fight>();
            fov = GetComponent<EnemyFov>();
            guardPose = transform.position;
        }
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (CharStat.isDead)
                return;

            if(PlayerInRange() && fight.canAttack(player))
            {
                AttackPlayer();
            }
            else if (lastSightTime < maxSusTime)
            {
                waitandlook();
            }
            else
            {
                GuardArea();
            }
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            if (lastSightTime < maxSusTime)
            {
                lastSightTime += Time.deltaTime;
            }
            if (timeSinceArrivedAtWayPoint <= WaypointDwellTime)
            {
                timeSinceArrivedAtWayPoint += Time.deltaTime;
            }
        }

        private void GuardArea()
        {
            Vector3 wayPointPos = guardPose;
            if (patrolPath)
            {
                if (AtWayPoint())
                {
                    timeSinceArrivedAtWayPoint = 0f;
                    CycleWaypoint();
                }
                wayPointPos = getCurrentWaypoint();
            }
            if (timeSinceArrivedAtWayPoint > WaypointDwellTime)
                GetComponent<Move>().StartMoveAction(wayPointPos,0.9f);
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private Vector3 getCurrentWaypoint()
        {
            return patrolPath.GetWayPoint(currentWaypointIndex);
        }

        private bool AtWayPoint()
        {
            return Vector3.Distance(transform.position, getCurrentWaypoint()) < WaypointDelta;
        }

        private void waitandlook()
        {
            fight.stopAction();
        }

        private void AttackPlayer()
        {
            lastSightTime = 0f;
            fight.attack(player);
        }

        private bool PlayerInRange()
        {
            return fov.FindEnemies();
        }

        //set by fov in player
        public void setPlayer(GameObject player)
        {
            if (this.player == player) return;
            this.player = player;
        }

        public void resetPlayer()
        {
            player = null;
        }
    }

}