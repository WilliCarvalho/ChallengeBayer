using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    public GameObject botaoVitoria;
    public GameObject fonteSom;
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
        }
    }

    public void SomVitoria()
    {
        StartCoroutine(EsperaSomVitoria());
    }

    IEnumerator EsperaSomVitoria()
    {
        fonteSom.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.0f);
        fonteSom.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Vitoria");
        
    }
}
