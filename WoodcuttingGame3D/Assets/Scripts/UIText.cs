using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    public Text woodcuttingLevelText;
    public Text currentExpText;
    public Text nextExpText;
    public Text goldText;

    public LevelSystem levelSystem;

   
    void Update()
    {
        woodcuttingLevelText.text = "Level: " + PlayerStats.instance.playerWoodcuttingLevel;
        currentExpText.text = "Current Lvl Exp: " + PlayerStats.instance.playerWoodcuttingCurrentExp;
        nextExpText.text = "Next Lvl Exp: " + levelSystem.nextLevelExperience;
        goldText.text = "Gold: " + PlayerStats.instance.gold;
    }
}
