using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : Character
{
    public GameObject tile;
    public GameObject fonteSomPlayer;
    public GameObject fonteSomSombra;
    public Player scriptplayer;
    public Animator animatorPlayer;
    public Animator animatorSombra;
    public GameObject managers;

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
                StartCoroutine(Espera());                
            }
        }

        if (tile.GetComponent<SwapTexture>().iluminado == true)
        {
            animatorSombra.SetTrigger("Die");
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
            Destroy(managers);
            scriptplayer.enabled = false;
            animatorPlayer.SetTrigger("Die");
            animatorSombra.SetTrigger("Attack");
            controle++;
            fonteSomSombra.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.0f);           
            fonteSomPlayer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.5f);
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
