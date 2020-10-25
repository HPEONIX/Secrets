using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(StateManager))]
    public class Move : MonoBehaviour, IActions
    {
        public float maxSpeed = 6f;
        public float speed;


        NavMeshAgent meshAgent;
        Animator CharAnim;

        private void Awake()
        {
            meshAgent = GetComponent<NavMeshAgent>();
            CharAnim = GetComponent<Animator>();
        }

        private void Update()
        {
            if(CharAnim!=null)
            {
                Vector3 globalspeed = meshAgent.velocity;
                Vector3 localVelocity = transform.InverseTransformDirection(globalspeed);
                speed = Mathf.Abs(localVelocity.z);
                CharAnim.SetFloat("Speed", speed);
            }
            
        }

        public void moveTo(Vector3 position, float SpeedFraction)
        {
            meshAgent.isStopped = false;
            meshAgent.speed = maxSpeed * SpeedFraction;
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

        internal void StartMoveAction(Vector3 destination, float SpeedFraction)
        {
            GetComponent<StateManager>().StartAction(this);
            moveTo(destination, SpeedFraction);
        }
    }

}