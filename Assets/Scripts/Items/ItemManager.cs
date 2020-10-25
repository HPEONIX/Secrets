using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject wayBlocker;

    int count ;
    // Start is called before the first frame update
    private void Start()
    {
        count = transform.childCount;
    }
    bool check()
    {
        return count == 0;
    }
    
    public void openDoor()
    {
        count -= 1;
        if (wayBlocker == null) return;
        if(check())
        {
            wayBlocker.SetActive(false);
            return;
        }
    }
}
