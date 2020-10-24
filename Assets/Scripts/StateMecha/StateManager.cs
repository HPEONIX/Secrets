using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    IActions currentState;

    public void StartAction(IActions newState)
    {
        if (currentState == newState) return;
        if (currentState != null) currentState.stopAction();
        currentState = newState;
    }

    public void stopAllActions()
    {
        StartAction(null);
    }
}
