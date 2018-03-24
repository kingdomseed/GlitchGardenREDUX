using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float LoadTimer;

    private void Start()
    {
        if(LoadTimer <= 0)
        {
            Debug.Log("Auto load disabled.");
        } else
        {
            Invoke("LoadNextLevel", LoadTimer);
        }
        
    }
    
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
