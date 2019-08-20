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
        if (Input.GetButtonDown("Fire1"))
        {
            currentTexture++;
            currentTexture %= texturas.Length;            
            GetComponent<Renderer>().material.mainTexture = texturas[currentTexture];
            iluminado = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (iluminado == false)
        {
            //Destroy(other.gameObject);
            //Instantiate(other, SpawnPoint.transform.position, transform.rotation);
            other.transform.position = SpawnPoint.transform.position;
            
        }
    }
}
