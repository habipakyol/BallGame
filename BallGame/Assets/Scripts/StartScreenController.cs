using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{

    public GameObject buttonObject; //Button objesini tan�ml�yoruz.
    public float toggleInterval = 1f; //Toggle i�leminin ka� saniyede bir yap�laca��n� belirliyoruz.

    private void Start()
    {
        StartCoroutine(ToggleButtonCoroutine()); //ToggleButtonCoroutine coroutine'unu ba�lat�yoruz.
    }

    private IEnumerator ToggleButtonCoroutine()
    {
        while (true) //Sonsuz d�ng� ile toggle i�lemini devam ettiriyoruz.
        {
            buttonObject.SetActive(!buttonObject.activeSelf); //Button objesinin aktif durumunu tersine �eviriyoruz.
            yield return new WaitForSeconds(toggleInterval); //Belirledi�imiz s�re kadar bekliyoruz.
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1); // Buradaki "1" y�klemek istedi�iniz sahnenin indeks numaras�d�r.
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


