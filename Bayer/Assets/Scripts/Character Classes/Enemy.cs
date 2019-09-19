using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : Character
{
    public GameObject tile;
    public GameObject fonteSomPlayer;
    public GameObject fonteSomSombra;
    private int controle;
    //public GameManager gameManager;
    public override void PhaseBehavior(TouchCommand command)
    {
        ;
    }
    public void Start()
    {
        //tile = GetComponent<Renderer>().material.mainTexture;        
    }
    public void Update()
    {
        RaycastHit hit;
        if (base.RaycastInDirection(facingDirection, out hit))
        {
            //Debug.DrawRay(transform.position, hit.transform.parent.position, Color.red);
            if (hit.transform.tag == "Player")
            {
                //Destroy(hit.transform.gameObject, 1.0f);
                StartCoroutine(Espera());                
            }
        }

        if (tile.GetComponent<SwapTexture>().iluminado == true)
        {
            GameObject manager = GameObject.Find("Managers");
            manager.GetComponent<GameManager>().removeFromEnemies(gameObject);
            Destroy(gameObject);
            //StartCoroutine(EsperaInimigo());

        }

    }
    IEnumerator Espera()
    {        
        if (controle == 0)
        {
            controle++;
            fonteSomSombra.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.0f);
            print("entrouaqui");
            fonteSomPlayer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("Grecia");
        }        
    }
     IEnumerator EsperaInimigo()
    {        
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    /// <summary>
    /// Enemy attack simply destroys the player.
    /// </summary>
    /// <param name="target"></param>
    public override void Attack(GameObject target)
    {
        Destroy(target);
    }  
}
