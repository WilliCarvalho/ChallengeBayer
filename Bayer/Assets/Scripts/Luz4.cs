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
    public GameObject luz;
    public Transform playerTransform;
    public Transform paredeTransform;
    public Animator playerAnimator;


    private bool intervalo;


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
        playerTransform.LookAt(paredeTransform);
        StartCoroutine(Espera());        
    }

    IEnumerator Espera()
    {
        playerAnimator.SetBool("Interagindo", true);
        yield return new WaitForSeconds(1.0f);
        playerAnimator.SetBool("Interagindo", false);
        bloco1.trocaTextura();
        bloco2.trocaTextura();
        bloco3.trocaTextura();
        botao.SetActive(false);
        luz.SetActive(true);
        interagiu = true;
        Destroy(gameObject);
    }
}
