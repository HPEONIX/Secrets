using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Move : MonoBehaviour
    {
        public float maxSpeed=6f;

        [Range(0,1)]
        public float speedCantrol=1f;

        NavMeshAgent meshAgent;

        private void Awake()
        {
            meshAgent = GetComponent<NavMeshAgent>();
        }
        public void moveTo(Vector3 position)
        {
            meshAgent.isStopped = false;
            setSpeed(speedCantrol);
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
            meshAgent.speed = maxSpeed * Mathf.Clamp01( speedCantrol);
        }


    }

}