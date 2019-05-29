using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("firstScene", 2f);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void firstScene()
    {
        SceneManager.LoadScene(1);
    }
}
