using System;
using System.Collections;
using System.Collections.Generic;
using Cantrollers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hlo");
        if (other.CompareTag("Player"))
        {
            Debug.Log("found");
            other.GetComponent<PlayerCantroller>().enabled = false;
            other.GetComponent<StateManager>().stopAllActions();
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        if (SceneManager.GetSceneByName(sceneToLoad) == null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCantroller>().enabled = true;
            Debug.Log("Notfound");
            yield break;
        }
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
