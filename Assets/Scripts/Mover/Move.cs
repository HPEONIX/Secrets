using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Move : MonoBehaviour, IActions
    {
        public float maxSpeed = 6f;


        NavMeshAgent meshAgent;

        private void Awake()
        {
            meshAgent = GetComponent<NavMeshAgent>();
        }
        public void moveTo(Vector3 position, float SpeedFraction)
        {
            meshAgent.isStopped = false;
            setSpeed(SpeedFraction);
            meshAgent.SetDestination(position);
        }
        public void pauseAction()
        {
            meshAgent.isStopped = true;
        }

        public void stopAction()
        {
            pauseAction();
            meshAgent.SetDestination(transform.position);
        }

        public void setSpeed(float speedCantrol)
        {
            meshAgent.speed = maxSpeed * Mathf.Clamp01(speedCantrol);
        }

        internal void StartMoveAction(Vector3 destination, float SpeedFraction)
        {
            GetComponent<StateManager>().StartAction(this);
            moveTo(destination, SpeedFraction);
        }
    }

}