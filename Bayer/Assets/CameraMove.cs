using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject cameraPrincipal;
    public float velocidade;
    private bool mover;
    private Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        endPosition = new Vector3(cameraPrincipal.transform.position.x, cameraPrincipal.transform.position.y, -20f);
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
            }
        }
    }
}
