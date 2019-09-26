using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject cameraPrincipal;
    public float velocidade;

    private bool mover;
    private bool mover2; 

    public GameObject proprioTrigger;
    public GameObject outroTrigger;
    public GameObject managers;
    public GameObject botoesInterface;

    private Vector3 endPosition;
    private Vector3 endPosition2;  

    // Start is called before the first frame update
    void Start()
    {
        endPosition = new Vector3(cameraPrincipal.transform.position.x, cameraPrincipal.transform.position.y, -20f);
        endPosition2 = new Vector3(cameraPrincipal.transform.position.x, 28f, cameraPrincipal.transform.position.z);        
        mover2 = true;
        managers.SetActive(false);
        botoesInterface.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        MoverCamera();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mover = true;
        }      
    }

    void MoverCamera()
    {
        if (mover)
        {
            cameraPrincipal.transform.Translate(0f,0f,1f * velocidade * Time.deltaTime, Space.World);
            if (cameraPrincipal.transform.position.z > endPosition.z)
            {
                mover = false;
                outroTrigger.SetActive(true);
                proprioTrigger.SetActive(false);
            }
        }

        else if (mover2)
        {
            cameraPrincipal.transform.Translate(0f, -1f * velocidade * Time.deltaTime, 0f, Space.World);
            if (cameraPrincipal.transform.position.y < endPosition2.y)
            {
                mover2 = false;
                managers.SetActive(true);
                botoesInterface.SetActive(true);
            }
        }        
    }
}
