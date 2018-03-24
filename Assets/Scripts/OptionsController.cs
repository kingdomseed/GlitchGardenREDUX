using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volume;
    public Slider difficulty;
    public LevelManager levelManager;
    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volume.value = PlayerPrefsManager.GetMasterVolume();
        difficulty.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume(volume.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volume.value);
        PlayerPrefsManager.SetDifficulty(difficulty.value);
        levelManager.LoadLevel("01a MainMenu");
    }

    public void SetDefaults()
    {
        volume.value = 0.8f;
        difficulty.value = 2f;
    }

}
