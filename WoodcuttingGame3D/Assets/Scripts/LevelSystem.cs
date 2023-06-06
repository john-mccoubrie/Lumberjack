using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int nextLevelExperience = 200;

    int basicTreeExp = 10;
    public Item logs;

    public float woodcuttingLevelMultiplier = 0.10f;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        nextLevelExperience = PlayerPrefs.GetInt("Next Level Experience", nextLevelExperience);
        PlayerStats.instance.playerWoodcuttingCurrentExp = PlayerPrefs.GetInt("Current Experience", PlayerStats.instance.playerWoodcuttingCurrentExp);
        PlayerStats.instance.playerWoodcuttingLevel = PlayerPrefs.GetInt("Current Level", PlayerStats.instance.playerWoodcuttingLevel);
        woodcuttingLevelMultiplier = PlayerPrefs.GetFloat("Level Multiplier", woodcuttingLevelMultiplier);
    }
    void OnEnable()
    {
        TreeController.AddExperience += Add_Experience;
    }
    void OnDisable()
    {
        TreeController.AddExperience -= Add_Experience;
    }

    private void Update()
    {
        LevelUp();
    }

    void Add_Experience()
    {
        PlayerPrefs.SetInt("Next Level Experience", nextLevelExperience);
        if(Random.value <= (0.2 + woodcuttingLevelMultiplier))
        {
            PlayerStats.instance.playerWoodcuttingCurrentExp += basicTreeExp;
            Inventory.instance.Add(logs);
        }
        PlayerPrefs.SetInt("Current Experience", PlayerStats.instance.playerWoodcuttingCurrentExp);
    }


    void LevelUp()
    {
        if(PlayerStats.instance.playerWoodcuttingCurrentExp >= nextLevelExperience)
        {
            PlayerStats.instance.playerWoodcuttingLevel++;
            Debug.Log("Congratulations! You are now Level " + PlayerStats.instance.playerWoodcuttingLevel);
            PlayerPrefs.SetInt("Current Level", PlayerStats.instance.playerWoodcuttingLevel);
            nextLevelExperience = (nextLevelExperience + 200) * 2;
            woodcuttingLevelMultiplier += .02f;
            PlayerPrefs.SetFloat("Level Multiplier", woodcuttingLevelMultiplier);
        }
    }
}
