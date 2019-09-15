using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz4 : MonoBehaviour
{
    public GameObject botao;
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public SwapTexture bloco3;
    public bool playerPresent = false;
    public bool interagiu;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && interagiu == false)
        {
            playerPresent = true;
            botao.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPresent = false;
            botao.SetActive(false);
        }
    }

    public void ButtonTexture()
    {
        {
            bloco1.trocaTextura();
            bloco2.trocaTextura();
            bloco3.trocaTextura();
            botao.SetActive(false);
            interagiu = true;
        }
    }
}
