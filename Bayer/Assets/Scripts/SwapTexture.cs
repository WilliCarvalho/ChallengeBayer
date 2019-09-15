using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTexture : MonoBehaviour
{
    public Texture[] texturas;
    public int currentTexture;
    public bool iluminado = false;
    public GameObject SpawnPoint;
    void Start()
    {
        
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
        if (iluminado == false)
        {
            //StartCoroutine(Destruir(other));
            //other.transform.position = SpawnPoint.transform.position;
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public IEnumerator Destruir(Collider c)
    {
        Instantiate(c, SpawnPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(c.gameObject);        
    }




}
