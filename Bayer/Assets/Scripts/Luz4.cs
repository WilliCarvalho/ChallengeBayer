﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz4 : MonoBehaviour
{
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public SwapTexture bloco3;
    public bool playerPresent = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresent == true)
        {
            bloco1.trocaTextura();
            bloco2.trocaTextura();
            bloco3.trocaTextura();     
        }
    }

    private void OnTriggerStay(Collider other)
    {
        playerPresent = true;
    }
}