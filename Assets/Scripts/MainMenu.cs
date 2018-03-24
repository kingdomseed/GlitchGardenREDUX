using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene ("01a MainMenu");
    }
}
