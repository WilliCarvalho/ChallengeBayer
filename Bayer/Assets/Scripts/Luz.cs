using System.Collections;
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
    public GameObject luz;
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
        botao.SetActive(false);
        StartCoroutine(Espera());
        if (intervalo == true)
        {
            bloco1.trocaTextura();
            bloco2.trocaTextura();            
            luz.SetActive(true);
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
