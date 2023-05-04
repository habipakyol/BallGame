using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UI uiManager;
    public Extracoin extracoin;
    public void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("para"));
        CoinCalculator(0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Finito"))
        {
            Debug.Log("oyun bitti"); 
            CoinCalculator(100);
            uiManager.CoinTextUP();
            uiManager.FinishScreen();
        }
    }

    //------NEDEN ÇALIÞMIYOOOOOOOOOOOR?????????------
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Finito"))
    //    {
    //        Debug.Log("oyun bitti");
    //        CoinCalculator(100);
    //        uiManager.CoinTextUP();
    //        uiManager.FinishScreen();
    //    }
    //}


    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("para"))
        {
            int eskiscor = PlayerPrefs.GetInt("para");
            PlayerPrefs.SetInt("para", eskiscor + money);
        }
        else
        {
            PlayerPrefs.SetInt("para", 50000);
        }
    } 
}
