﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Luz : MonoBehaviour
{
    public GameObject botao;
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public bool playerPresent = false;
    public bool interagiu;

    // Start is called before the first frame update

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
            bloco1.trocaTextura();
            bloco2.trocaTextura();
            botao.SetActive(false);
            interagiu = true;
    }
}
