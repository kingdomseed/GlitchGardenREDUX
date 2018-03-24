using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter2D()
    {
        levelManager.LoadLevel("03a Lose");
    }
}
