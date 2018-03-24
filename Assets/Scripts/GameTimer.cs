using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEnd = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        YouWin();
    }

    private void YouWin()
    {
        
        winLabel = GameObject.Find("Win");
        if (!winLabel)
        {
            Debug.LogWarning("No Win Label Game Object");
        }
        winLabel.SetActive(false);
    }

    void Update ()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEnd)
        {
            HandleWin();
        }
    }

    private void HandleWin()
    {
        DestroyAllTaggedObjects();
        winLabel.SetActive(true);
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEnd = true;
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("Destroy");
        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel ()
    {
        levelManager.LoadNextLevel();
    }
}
