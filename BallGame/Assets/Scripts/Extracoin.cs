using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extracoin : MonoBehaviour
{
    public UI uimanager;


    public void ExtrasCoinAd()
    {
        CoinCalculator(400);
        uimanager.StartCoroutine("ClaimButtonF");
    }

    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("para"))
        {
            int eskiscor = PlayerPrefs.GetInt("para");
            PlayerPrefs.SetInt("para", eskiscor + money);
        }
        else
        {
            PlayerPrefs.SetInt("para", 0);
        }
    }
}
