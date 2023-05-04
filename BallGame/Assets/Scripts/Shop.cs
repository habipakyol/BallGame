using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public UI uimanager;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;

    public Sprite YellowImage;
    public Sprite GreenImage;

    public GameObject Item;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject Lock4;

    public void Start()
    {
        //---Kilit-----
        if (PlayerPrefs.HasKey("Lock2Control"))
            PlayerPrefs.SetInt("Lock2Control", 0);

        if (PlayerPrefs.HasKey("Lock3Control"))
            PlayerPrefs.SetInt("Lock3Control", 0);

        if (PlayerPrefs.HasKey("Lock4Control"))
            PlayerPrefs.SetInt("Lock4Control", 0);

        if(PlayerPrefs.GetInt("Lock2Control")==1)
            Lock2.SetActive(false);

        if (PlayerPrefs.GetInt("Lock3Control") == 1)
            Lock3.SetActive(false);

        if (PlayerPrefs.GetInt("Lock4Control") == 1)
            Lock4.SetActive(false);
    }

    public void Item1Open()
    {
        particle1.SetActive(true);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);

        Item.GetComponent<Image>().sprite = GreenImage;
        Item2.GetComponent<Image>().sprite = YellowImage;
        Item3.GetComponent<Image>().sprite = YellowImage;
        Item4.GetComponent<Image>().sprite = YellowImage;

    }
    public void Item2Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);

        Item.GetComponent<Image>().sprite = YellowImage;
        Item2.GetComponent<Image>().sprite = GreenImage;
        Item3.GetComponent<Image>().sprite = YellowImage;
        Item4.GetComponent<Image>().sprite = YellowImage;

    }
    public void Item3Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(true);
        particle4.SetActive(false);

        Item.GetComponent<Image>().sprite = YellowImage;
        Item2.GetComponent<Image>().sprite = YellowImage;
        Item3.GetComponent<Image>().sprite = GreenImage;
        Item4.GetComponent<Image>().sprite = YellowImage;

    }

    public void Item4Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(true);

        Item.GetComponent<Image>().sprite = YellowImage;
        Item2.GetComponent<Image>().sprite = YellowImage;
        Item3.GetComponent<Image>().sprite = YellowImage;
        Item4.GetComponent<Image>().sprite = GreenImage;
    }


    //---------Kilit------------

    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("para");
        int lock2control = PlayerPrefs.GetInt("Lock2Control");
        if (money >= 1000 && lock2control == 0)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("para", money - 1000);
            PlayerPrefs.SetInt("Lock2Control", 1);
            Item2Open();
            uimanager.CoinTextUP();
        }
    }

    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("para");
        int lock3control = PlayerPrefs.GetInt("Lock3Control");
        if (money >= 3000 && lock3control == 0)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("para", money - 3000);
            PlayerPrefs.SetInt("Lock3Control", 1);
            Item3Open();
            uimanager.CoinTextUP();
        }
    }
    public void Lock4Open()
    {
        int money = PlayerPrefs.GetInt("para");
        int lock4control = PlayerPrefs.GetInt("Lock4Control");
        if (money >= 10000 && lock4control == 0)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("para", money - 10000);
            PlayerPrefs.SetInt("Lock4Control", 1);
            Item4Open();
            uimanager.CoinTextUP();
        }
    }
}
