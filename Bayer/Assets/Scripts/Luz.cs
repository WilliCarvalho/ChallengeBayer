using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Luz : MonoBehaviour
{
    public GameObject botao;
    public SwapTexture bloco1;
    public SwapTexture bloco2;
    public bool playerPresent = false;
    public bool interagiu;
    public GameObject luz;
    public Transform playerTransform;
    public Transform paredeTransform;
    public Animator playerAnimator;
    private bool intervalo;

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
        luz.SetActive(true);
        botao.SetActive(false);
        interagiu = true;
        Destroy(gameObject);
    }

    
}
