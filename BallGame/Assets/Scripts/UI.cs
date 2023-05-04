using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//HABÝP AKYOL
public class UI : MonoBehaviour
{
    public Image beyazeffectimage;

    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinishLine;

    private int effectkontrol = 0;
    private bool radyalshine;
    public Text Coin_Text;

    public Animator LayoutAnim;

    //Butonlar
    public GameObject settings_open;
    public GameObject settings_close;
    public GameObject settings_background;

    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject Vibration_on;
    public GameObject Vibration_off;
    public GameObject iap;
    public GameObject information;

    public GameObject introfinger;
    public GameObject touchtomove_text;
    public GameObject noAds_button;
    public GameObject shop_button;


    public GameObject RestartScreen;

    //oyun sonu ekraný
    public GameObject finishScreen;

    public GameObject siyahBackground;

    public GameObject Completed;

    public GameObject Radyal;

    public GameObject coin;
    public GameObject ExtraCoin;


    public GameObject BuyMeButton;

    public GameObject ClaimButton;

    public GameObject NextLevel;

    public GameObject DontWant;

    public Text achievedText;




    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        CoinTextUP();
    }

    public void Update()
    {
        if (radyalshine == true)
        {
            Radyal.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 17f * Time.deltaTime));
        }
        FillRateImage.fillAmount = ((Player.transform.position.z * 100) / (FinishLine.transform.position.z)) / 100;


    }
    public string url;

    public void Open()
    {
        Application.OpenURL("https://www.buymeacoffee.com/habipakyol");
    }
    public void FirstTouch()
    {
        introfinger.SetActive(false);
        touchtomove_text.SetActive(false);
        noAds_button.SetActive(false);
        shop_button.SetActive(false);
        settings_open.SetActive(false);
        settings_close.SetActive(false);
        settings_background.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        Vibration_on.SetActive(false);
        Vibration_off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }

    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Veriable.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        Veriable.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunc");
    }

    public IEnumerator FinishLaunc()
    {
        Time.timeScale = 0.5f;
        radyalshine = true;
        finishScreen.SetActive(true);
        siyahBackground.SetActive(true);
        Completed.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        Radyal.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        BuyMeButton.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        ClaimButton.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        DontWant.SetActive(true);
    }

    public void NextLevelScrenn()
    {
        StartCoroutine("ClaimButtonF");

    }

    public IEnumerator ClaimButtonF()
    {

        ClaimButton.SetActive(false);
        DontWant.SetActive(false);
        ExtraCoin.SetActive(true);
        achievedText.gameObject.SetActive(true);
        for (int i = 0; i < 301; i++)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSecondsRealtime(0.005f);
        }
        BuyMeButton.SetActive(false);

        yield return new WaitForSecondsRealtime(1f);
        NextLevel.SetActive(true);


    }





    public void CoinTextUP()
    {
        Coin_Text.text = PlayerPrefs.GetInt("para").ToString();
    }


    public void OnPreCull()
    {
        Application.OpenURL("");
    }


    public void TermOfUse()
    {
        Application.OpenURL("");
    }


    public void Settings_Open()
    {
        settings_open.SetActive(false);
        settings_close.SetActive(true);
        LayoutAnim.SetTrigger("Slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }



        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            Vibration_on.SetActive(true);
            Vibration_off.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            Vibration_on.SetActive(false);
            Vibration_off.SetActive(true);
        }

    }

    public void Settings_Close()
    {
        settings_open.SetActive(true);
        settings_close.SetActive(false);
        LayoutAnim.SetTrigger("Slide_out");
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        Vibration_on.SetActive(false);
        Vibration_off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }
    public void Vibration_Off()
    {
        Vibration_on.SetActive(true);
        Vibration_off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }












    public IEnumerator BeyazEffect()
    {
        beyazeffectimage.gameObject.SetActive(true);
        while (effectkontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            beyazeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (beyazeffectimage.color == new Color(beyazeffectimage.color.r, beyazeffectimage.color.g, beyazeffectimage.color.b, 1f))
            {
                effectkontrol = 1;
            }
        }

        while (effectkontrol == 1)
        {
            yield return new WaitForSeconds(0.001f);
            beyazeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (beyazeffectimage.color == new Color(beyazeffectimage.color.r, beyazeffectimage.color.g, beyazeffectimage.color.b, 0f))
            {
                effectkontrol = 2;
            }
        }

        if (effectkontrol == 2)
        {
            Debug.Log("Efekt bitti.");
        }

    }
}
