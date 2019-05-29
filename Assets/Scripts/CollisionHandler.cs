using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        startDeathSeq();
        deathFX.SetActive(true);
        Invoke("reloadScene", levelLoadDelay);
    }

    private void startDeathSeq()
    {
        SendMessage("OnPlayerDeath");

    }

    private void reloadScene()
    {
        SceneManager.LoadScene(1);
    }


}
