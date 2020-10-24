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
            GetComponent<FieldOfView>().FindEnemies();
            if (CharStat.isDead)
                return;
            if (respondAction())
                return;
            if (movementAction())
                return;
        
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
            if (Input.GetMouseButtonDown(0))
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
                GetComponent<Move>().moveTo(hit.point);
                return true;
            }
            return false;
        }
    }
}