using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject porta;
    public GameObject botao;
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public SwapTexture bloco3;
    public SwapTexture bloco4;
    public bool interagiu;
    public Transform playerTransform;
    public Transform paredeTransform;
    public Animator playerAnimator;

    private bool intervalo;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && interagiu == false)
        {
            botao.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            botao.SetActive(false);
        }
    }

    public void AbrirPorta()
    {
        playerTransform.LookAt(paredeTransform);
        StartCoroutine(Espera());        
    }

    IEnumerator Espera()
    {
        playerAnimator.SetBool("Interagindo", true);
        yield return new WaitForSeconds(1.0f);
        playerAnimator.SetBool("Interagindo", false);
        interagiu = true;
        botao.SetActive(false);
        bloco1.trocaTextura();
        bloco2.trocaTextura();
        bloco3.trocaTextura();
        bloco4.trocaTextura();
        Destroy(porta);
    }

}
