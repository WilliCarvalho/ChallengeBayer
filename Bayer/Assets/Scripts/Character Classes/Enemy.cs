using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    public GameObject tile;
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
                Destroy(hit.transform.gameObject, 1.0f);
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
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel(Application.loadedLevel);
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
