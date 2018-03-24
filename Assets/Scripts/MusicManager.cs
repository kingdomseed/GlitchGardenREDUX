using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip thisLevelsMusic;
    public AudioClip[] levelMusicChangeArray;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {

        if (scene.buildIndex == 0)
        {
            thisLevelsMusic = levelMusicChangeArray[0];
        } else {
            thisLevelsMusic = levelMusicChangeArray[1];
        }
        
        if (thisLevelsMusic && thisLevelsMusic != audioSource.clip)
        {
            Debug.Log("Playing music: " + thisLevelsMusic);
            audioSource.clip = thisLevelsMusic;
            audioSource.Play();

        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    //private void OnLevelWasLoaded(int level)
    //{
    //    if (level >= 1)
    //    {
    //        Debug.Log("Detected!");
    //        audioSource.clip = levelMusicChangeArray[1];
    //        audioSource.Play();
    //    }
    //}

}
