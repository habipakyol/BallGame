using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{

    public GameObject buttonObject; //Button objesini tanýmlýyoruz.
    public float toggleInterval = 1f; //Toggle iþleminin kaç saniyede bir yapýlacaðýný belirliyoruz.

    private void Start()
    {
        StartCoroutine(ToggleButtonCoroutine()); //ToggleButtonCoroutine coroutine'unu baþlatýyoruz.
    }

    private IEnumerator ToggleButtonCoroutine()
    {
        while (true) //Sonsuz döngü ile toggle iþlemini devam ettiriyoruz.
        {
            buttonObject.SetActive(!buttonObject.activeSelf); //Button objesinin aktif durumunu tersine çeviriyoruz.
            yield return new WaitForSeconds(toggleInterval); //Belirlediðimiz süre kadar bekliyoruz.
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1); // Buradaki "1" yüklemek istediðiniz sahnenin indeks numarasýdýr.
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


    public string url;

    public void Open()
    {
        Application.OpenURL("https://www.buymeacoffee.com/habipakyol");
    }
}


