using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{  
    public GameObject menuInicial;
    public GameObject menuOptions;
    public GameObject menuDescontos;
    public GameObject menuMapas;
    public GameObject titulo;
    public GameObject introducao;


    private int i = 0;
    public GameObject texto1, texto2, texto3, texto4, texto5, texto6;
  
    private void Start()
    {
        ShowMenu(menuInicial);
    }
    //private void Update()
    //{        
       
    //} 

    public void PularIntro()
    {
        SceneManager.LoadScene("MenuInicial");
    }        
    public void AtivarTexto(GameObject texto)
    {
        texto1.SetActive(false);
        texto2.SetActive(false);
        texto3.SetActive(false);
        texto4.SetActive(false);
        texto5.SetActive(false);
        texto6.SetActive(false);
        texto.SetActive(true);
    }

    public void AvancaTexto()
    {                
        i++;
        if (i == 1)
        {
            AtivarTexto(texto2);
        }
        else if(i == 2)
        {
            AtivarTexto(texto3);
        }
        else if (i == 3)
        {
            AtivarTexto(texto4);
        }
        else if (i == 4)
        {
            AtivarTexto(texto5);
        }
        else if (i == 5)
        {
            AtivarTexto(texto6);
        }
        else if (i == 6)
        {
            SceneManager.LoadScene("Grecia");
        }        
    }
    public void GameGrecia()
    {
        SceneManager.LoadScene("Grecia");
    }
    public void ShowPopUp(GameObject popup)
    {
        popup.SetActive(true);
    }
    public void HidePopUp(GameObject popup)
    {
        popup.SetActive(false);
    }
    public void HideMenus()
    {       
        menuInicial.SetActive(false);
        menuOptions.SetActive(false);
        menuDescontos.SetActive(false);
        menuMapas.SetActive(false);
        introducao.SetActive(false);
    }
    public void ShowMenu(GameObject menu)
    {
        StartCoroutine(Espera(menu));
        
    }        
   
    IEnumerator Espera(GameObject menu)
    {
        yield return new WaitForSeconds(0.3f);
        HideMenus();
        menu.SetActive(true);
    }
}
