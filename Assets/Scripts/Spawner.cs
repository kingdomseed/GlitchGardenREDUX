using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] PrefabAttacker;

    private void Update()
    {
        foreach (GameObject thisAttacker in PrefabAttacker)
        {
            if(isTimeToSpawn (thisAttacker))
            {
                Spawn (thisAttacker);
            }
        }
    }

    bool isTimeToSpawn(GameObject attackerGO)
    {
        Attacker att = attackerGO.GetComponent<Attacker>();
        float meanSpawnDelay = att.seenEverySeconds;
        float spawnsPerSecond = 1f / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by framerate.");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold);
    }

    void Spawn (GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

}
