using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz3 : MonoBehaviour
{
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public SwapTexture bloco3;
    public SwapTexture bloco4;
    public SwapTexture bloco5;
    public SwapTexture bloco6;
    public SwapTexture bloco7;
    public SwapTexture bloco8;
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
            bloco4.trocaTextura();
            bloco5.trocaTextura();
            bloco6.trocaTextura();
            bloco7.trocaTextura();
            bloco8.trocaTextura();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        playerPresent = true;
    }
}
