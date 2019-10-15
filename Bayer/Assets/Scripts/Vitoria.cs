using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    public GameObject botaoVitoria;
    public GameObject fonteSom;
    public GameObject managers;
    public Transform playerTransform;
    public Transform paredeTransform;
    public Transform hipocratesTransform;
    public Animator playerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            botaoVitoria.SetActive(true);
            managers.SetActive(false);
        }
    }

    public void SomVitoria()
    {
        hipocratesTransform.LookAt(playerTransform);
        playerTransform.LookAt(paredeTransform);
        StartCoroutine(EsperaSomVitoria());
    }

    IEnumerator EsperaSomVitoria()
    {
        playerAnimator.SetBool("Interagindo", true);
        yield return new WaitForSeconds(1.0f);
        playerAnimator.SetBool("Interagindo", false);
        fonteSom.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.0f);
        fonteSom.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Vitoria");
        
    }
}
