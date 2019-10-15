using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject popupOptions;
    public GameObject popupRestart;
    public GameObject botoesInterface;
    public GameObject managers;
    public GameObject tileVitoria;
    public GameObject botaoVitoria;
    public bool tutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial && tileVitoria.GetComponent<SwapTexture>().iluminado == true)
        {
            print("foi");
            botaoVitoria.SetActive(true);
        }
    }

    public void FecharPopUp(GameObject popup)
    {
        popup.SetActive(false);
        botoesInterface.SetActive(true);
        managers.SetActive(true);
    }
    public void ShowMenu(GameObject menu)
    {
        HideMenus();
        menu.SetActive(true);
    }
    public void HideMenus()
    {
        popupOptions.SetActive(false);
        popupRestart.SetActive(false);
        botoesInterface.SetActive(false);
        managers.SetActive(false);
    }
    public void Restart()
    {
        StartCoroutine(EsperaRestart());
    }

    IEnumerator EsperaRestart()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Grecia");
    }

    public void ReturnMenu()
    {
        StartCoroutine(EsperaReturnMenu());
    }

    IEnumerator EsperaReturnMenu()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MenuInicial");
    }
    public void RestartTutorial()
    {
        StartCoroutine(RestartTuto());
    }

    IEnumerator RestartTuto()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Tutorial");
    }
}
