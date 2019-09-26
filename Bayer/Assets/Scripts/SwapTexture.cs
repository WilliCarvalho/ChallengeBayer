using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapTexture : MonoBehaviour
{
    public Texture[] texturas;
    public int currentTexture;
    public bool iluminado = false;
    public GameObject SpawnPoint;
    public GameObject fonte;
    public Animator playeranimator;
    public GameObject managers;
    public GameObject player;
    private Vector3 playerStartPosition;
    void Start()
    {
        playerStartPosition = player.transform.position;
    }
    
    void Update()
    {
        
    }

    public void trocaTextura()
    {       
            currentTexture++;
            currentTexture %= texturas.Length;   
            GetComponent<Renderer>().material.mainTexture = texturas[currentTexture];
            iluminado = true;        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (iluminado == false && other.gameObject.tag == "Player")
        {
            //StartCoroutine(Destruir(other));
            //other.transform.position = SpawnPoint.transform.position;
            StartCoroutine(RestartEscuridão());            
        }
    }

    public IEnumerator Destruir(Collider c)
    {
        Instantiate(c, SpawnPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(c.gameObject);        
    }

    IEnumerator RestartEscuridão()
    {
        Destroy(managers);
        playeranimator.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);
        fonte.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        //player.transform.position = playerStartPosition;
       // player.GetComponent<Animator>().SetTrigger("Die");
        SceneManager.LoadScene("Grecia");
    }




}
