using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("firstScene", 2f);
    }



    private void firstScene()
    {
        SceneManager.LoadScene(1);
    }
}
