using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public GameObject logoFiap;
    public GameObject logoBayer;
    public GameObject logoMemories;
    public RectTransform rectTransform;


    Vector3 startPosition = new Vector3(0f, 0f);
    Vector3 endPosition = new Vector3(0f, 340f);
    float timeOfTravel = 250; //time after object reach a target place 
    float currentTime = 0;
    float normalizedValue;
    // Start is called before the first frame update
    void Start()
    {
        ShowMenu(logoFiap);
        StartCoroutine(FadeInAndOutFiap());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("MenuInicial");
        }
    }    
    IEnumerator FadeInAndOutFiap()
    {
        logoFiap.GetComponent<CanvasGroup>().alpha = 0;
        bool fadeinFiap = false;
        bool fadeoutFiap = false;
        while (logoFiap.GetComponent<CanvasGroup>().alpha < 1)
        {
            logoFiap.GetComponent<CanvasGroup>().alpha += Time.deltaTime / 2;
            fadeinFiap = true;
            yield return null;
        }

        if (fadeinFiap == true)
        {
            while (logoFiap.GetComponent<CanvasGroup>().alpha > 0)
            {
                logoFiap.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 2;
                fadeoutFiap = true;
                yield return null;
            }
        }
        if (fadeoutFiap == true)
        {
            ShowMenu(logoBayer);
            StartCoroutine(FadeInandOutBayer());
        }

    }

    IEnumerator FadeInandOutBayer()
    {
        logoBayer.GetComponent<CanvasGroup>().alpha = 0;
        bool fadeinBayer = false;
        bool fadeoutBayer = false;
        while (logoBayer.GetComponent<CanvasGroup>().alpha < 1)
        {
            logoBayer.GetComponent<CanvasGroup>().alpha += Time.deltaTime / 2;
            fadeinBayer = true;
            yield return null;
        }

        if (fadeinBayer == true)
        {
            while (logoBayer.GetComponent<CanvasGroup>().alpha > 0)
            {
                logoBayer.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 2;
                fadeoutBayer = true;
                yield return null;
            }
        }
        if (fadeoutBayer == true)
        {
            ShowMenu(logoMemories);
            StartCoroutine(FadeInMemories());
        }
    }

    IEnumerator FadeInMemories()
    {
        logoMemories.GetComponent<CanvasGroup>().alpha = 0;
        while (logoMemories.GetComponent<CanvasGroup>().alpha < 1)
        {
            logoMemories.GetComponent<CanvasGroup>().alpha += Time.deltaTime / 2;
            StartCoroutine(MoveObject());
            yield return null;
        }
    }

    IEnumerator MoveObject()
    {
        bool foi = false;
        while (currentTime <= timeOfTravel)
       {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
            foi = true;
            yield return null;
        }
        if (foi == true)
        {
            SceneManager.LoadScene("MenuInicial");
        }
    }

    public void HideMenus()
    {
        logoBayer.SetActive(false);
        logoFiap.SetActive(false);
        logoMemories.SetActive(false);        
    }

    public void ShowMenu(GameObject menu)
    {
        HideMenus();
        menu.SetActive(true);
    }

    
}
