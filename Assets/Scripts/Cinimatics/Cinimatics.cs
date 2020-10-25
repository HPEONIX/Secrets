using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CinimaticsCantrolRemover))]
public class Cinimatics : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                GetComponent<PlayableDirector>().Play();
                GetComponent<BoxCollider>().enabled = false;
                
            }
                
        }
    }
