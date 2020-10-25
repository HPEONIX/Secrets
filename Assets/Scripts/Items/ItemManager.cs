using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject wayBlocker;

    int count =>transform.childCount;
    // Start is called before the first frame update
    bool check()
    {
        return count == 0;
    }
}
