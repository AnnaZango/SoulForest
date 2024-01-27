using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGame : MonoBehaviour
{
    [SerializeField] Light[] lightsToSetBrightness;
    [SerializeField] float[] probabilitiesItemDropEnemies = new float[3] { 0.1f, 0.25f, 0.4f};
    [SerializeField] float[] timesBetweenEnemySpawns = new float[3] { 300, 600, 1000};
    [SerializeField] int[] numEnemiesToSpawn = new int[3] { 5, 10, 15 };
    


    void Start()
    {
        AudioListener.volume = GameManager.volumeGame;

        foreach (Light light in lightsToSetBrightness)
        {
            light.intensity = GameManager.globalBrightness;
        }
    }

    public float GetProbabilityItemDrop()
    {
        return probabilitiesItemDropEnemies[GameManager.difficultyLevel];
    }

    public float GetTimeBetweenEnemySpawns()
    {
        return timesBetweenEnemySpawns[GameManager.difficultyLevel];
    }
    
    public int GetNumEnemiesToSpawn()
    {
        return numEnemiesToSpawn[GameManager.difficultyLevel];
    }
}
