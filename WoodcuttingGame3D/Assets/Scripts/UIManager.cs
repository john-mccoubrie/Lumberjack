using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public GameObject bobsWindow;
    public GameObject joesWindow;
    public void BobChangeInvestmentButton()
    {
        bobsWindow.SetActive(true);
        joesWindow.SetActive(false);
    }
    public void JoeChangeInvestmentButton()
    {
        joesWindow.SetActive(true);
        bobsWindow.SetActive(false);
    }
}
