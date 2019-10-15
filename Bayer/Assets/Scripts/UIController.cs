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
    public GameObject cameraVideo;
    public GameObject cameraMain;

    public GameObject botao1, botao2, botao3, botao4, botao5, botao6, botao7, botao8, botao9, botao10;


    private int i = 0;
    public GameObject texto1, texto2, texto3, texto4;
  
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
            //HideMenus();
            cameraVideo.SetActive(true);
        }
        else if (i == 5)
        {
            SceneManager.LoadScene("Tutorial");
        }        
    }
    public void GameGrecia()
    {
        SceneManager.LoadScene("Grecia");
    }
    public void ShowPopUp(GameObject popup)
    {
        popup.SetActive(true);
        botao1.GetComponent<Button>().interactable = false;
        botao2.GetComponent<Button>().interactable = false;
        botao3.GetComponent<Button>().interactable = false;
        botao4.GetComponent<Button>().interactable = false;
        botao5.GetComponent<Button>().interactable = false;
        botao6.GetComponent<Button>().interactable = false;
        botao7.GetComponent<Button>().interactable = false;
        botao8.GetComponent<Button>().interactable = false;
        botao9.GetComponent<Button>().interactable = false;
        botao10.GetComponent<Button>().interactable = false;
    }
    public void HidePopUp(GameObject popup)
    {
        botao1.GetComponent<Button>().interactable = true;
        botao2.GetComponent<Button>().interactable = true;
        botao3.GetComponent<Button>().interactable = true;
        botao4.GetComponent<Button>().interactable = true;
        botao5.GetComponent<Button>().interactable = true;
        botao6.GetComponent<Button>().interactable = true;
        botao7.GetComponent<Button>().interactable = true;
        botao8.GetComponent<Button>().interactable = true;
        botao9.GetComponent<Button>().interactable = true;
        botao10.GetComponent<Button>().interactable = true;
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
