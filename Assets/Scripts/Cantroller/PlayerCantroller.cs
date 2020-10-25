using System;
using System.Collections;
using System.Collections.Generic;
using movement;
using UnityEngine;

namespace Cantrollers
{ 
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Status))]
    public class PlayerCantroller : MonoBehaviour
    {

        Status CharStat;
        public float sprintSpeed;
        public float MaxSprintTime=2f;
        public float elapsedSprintTime=0;
        bool canRun = true;
        [Range(0, 1)]
        public float walkSpeed;

        private void Awake()
        {
            CharStat=GetComponent<Status>();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

            //GetComponent<FieldOfView>().FindEnemies();
            if (CharStat.isDead)
                return;
            ExtraCheck();

            if (respondAction())
                return;
            if (movementAction())
                return;
        
        }

        private void ExtraCheck()
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if(elapsedSprintTime < MaxSprintTime && canRun && GetComponent<Move>().speed>0.5)
                {
                    sprintSpeed = 1f;
                    elapsedSprintTime += Time.deltaTime;
                }
                else
                {
                    canRun = false;
                    sprintSpeed = walkSpeed;
                    if (elapsedSprintTime > 0)
                        elapsedSprintTime -= Time.deltaTime;
                    if (elapsedSprintTime <= 0)
                    {
                        elapsedSprintTime = 0;
                        canRun = true;
                    }
                }
            }
            else
            {
                sprintSpeed = walkSpeed;
                if (elapsedSprintTime>0)
                    elapsedSprintTime -= Time.deltaTime;
                if(elapsedSprintTime <= 0)
                {
                    elapsedSprintTime = 0;
                    canRun = true;
                }
            }
        }

        //todo : interact with interactable
        private bool respondAction()
        {
            return false;
        }

        private bool movementAction()
        {
            Vector2 screenpos = default;
            screenpos = GetScreenPos();
            if (screenpos == null || screenpos == default) return false;
            return movetoWorldPoint(screenpos);


        }

        private static Vector2 GetScreenPos()
        {
            if (Input.GetMouseButton(0))
            {
                return Input.mousePosition;
            }
            if (Input.touchCount > 0)
            {
                return Input.GetTouch(0).position;
            }
            return default;
        }

        private bool movetoWorldPoint(Vector2 screenpos)
        {
            var touch_ray = Camera.main.ScreenPointToRay(screenpos);
            RaycastHit hit;
            if (Physics.Raycast(touch_ray,out hit))
            {
                GetComponent<Move>().StartMoveAction(hit.point,sprintSpeed);
                return true;
            }
            return false;
        }
    }
}