﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_"; // "level_unlocked_1 for example.

   public static void SetMasterVolume(float volume)
    {
        if(volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range.");
        }
    }

    public static float GetMasterVolume()
    {
       return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if(level <= SceneManager.sceneCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); 
            // Use 1 for true.
        }
        else
        {
            Debug.LogError("Level not found in build order.");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Level not found in build order. (Query)");
            return false;
        }
    }

    public static void SetDifficulty(float diff)
    {
        if(diff >= 1f && diff <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        } else
        {
            Debug.LogError("Difficulty level out of range.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
