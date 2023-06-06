using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public float health;
    public float gold = 100f;
    public float goldInvestment = 1.5f;

    public int playerWoodcuttingCurrentExp;
    public int playerWoodcuttingLevel;
    public float woodcuttingLevelMultiplier = 0.02f;


    private void Awake()
    {
        instance = this;
        PlayerPrefs.GetFloat("Player Gold", gold);
    }

    void InvestmentGoldIncrease()
    {
        //gold *= goldInvestment;
        //PlayerPrefs.SetFloat("Player Gold", gold);
    }
}
