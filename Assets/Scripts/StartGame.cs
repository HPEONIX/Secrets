using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Screen;
    public GameObject Hint;
    public GameObject Player;
    public void StartNow()
    {
        Debug.Log("yes");
        Screen.SetActive(false);
        Hint.SetActive(true);
        Player.GetComponent<Cantrollers.PlayerCantroller>().enabled=true;
    }
}
