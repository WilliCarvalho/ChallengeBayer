using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject managers;

    public GameObject tutorialTexto, tutorialInterface;

    public GameObject tileVitoria;
    public GameObject botaoVitoria;

    public GameObject texto1, texto2, texto3, texto4, texto5;

    private bool controle;
    private int i;
    private static bool primeiraVez = false;
    // Start is called before the first frame update
    void Start()
    {
        managers.SetActive(false);
        tutorialInterface.SetActive(false);
        tutorialTexto.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (primeiraVez == true && controle == false)
        {
            tutorialTexto.SetActive(false);
            tutorialInterface.SetActive(true);
            managers.SetActive(true);
            controle = true;
        }

        if (tileVitoria.GetComponent<SwapTexture>().iluminado == true)
        {
            print("foi");
            botaoVitoria.SetActive(true);
        }
    }
    public void AvancaTexto()
    {
        i++;
        if (i == 1)
        {
            AtivarTexto(texto2);
        }
        else if (i == 2)
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
            tutorialInterface.SetActive(true);
            managers.SetActive(true);
            tutorialTexto.SetActive(false);
            primeiraVez = true;
        }
    }

    public void AtivarTexto(GameObject texto)
    {
        texto1.SetActive(false);
        texto2.SetActive(false);
        texto3.SetActive(false);
        texto4.SetActive(false);
        texto5.SetActive(false);
        texto.SetActive(true);
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
