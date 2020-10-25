using System.Collections;
using System.Collections.Generic;
using Cantrollers;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinimatics
{
    public class CinimaticsCantrolRemover : MonoBehaviour
    {
        GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<PlayableDirector>().played += disableCantrol;
            GetComponent<PlayableDirector>().stopped += enableCantrol;
        }

        void disableCantrol(PlayableDirector pd)
        {
            player.GetComponent<StateManager>().stopAllActions(); ;
            player.GetComponent<PlayerCantroller>().enabled=false;
        }

        void enableCantrol(PlayableDirector pd)
        {
            player.GetComponent<PlayerCantroller>().enabled = true;
        }
    }
}
