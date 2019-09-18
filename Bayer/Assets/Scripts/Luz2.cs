using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz2 : MonoBehaviour
{
    public GameObject botao;
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public SwapTexture bloco3;
    public SwapTexture bloco4;
    public SwapTexture bloco5;
    public SwapTexture bloco6;
    public SwapTexture bloco7;  
    public bool playerPresent = false;
    public bool interagiu;


    private bool intervalo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        StartCoroutine(Espera());
        if (intervalo == true)
        {
            bloco1.trocaTextura();
            bloco2.trocaTextura();
            bloco3.trocaTextura();
            bloco4.trocaTextura();
            bloco5.trocaTextura();
            bloco6.trocaTextura();
            bloco7.trocaTextura();
            botao.SetActive(false);
            interagiu = true;
            Destroy(gameObject);
        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1.0f);
        intervalo = true;
        ButtonTexture();
    }
}
