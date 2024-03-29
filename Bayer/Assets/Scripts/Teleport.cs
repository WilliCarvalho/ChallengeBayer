﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Moves player and camera to new location
/// </summary>
public class Teleport : MonoBehaviour
{
    public GameObject destination;
    public CameraManager cameraManager;
    public GameObject targetLocation;

    public void Start()
    {
        cameraManager = GameObject.Find("Managers").GetComponent<CameraManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Trigger entered");
        if (destination != null)
        {
            UnityEngine.AI.NavMeshAgent agent = other.GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.enabled = false;
            Vector3 navMeshPoint = destination.GetComponent<Tile>().getTileLocation();
            other.transform.position = navMeshPoint;
            agent.enabled = true;
            other.GetComponent<Character>().HasJustTeleported = true;
            other.transform.GetComponent<Player>().StopCoroutine("animCoroutine");
            StartCoroutine(cameraManager.CameraLerp(targetLocation.transform.position, targetLocation.transform.rotation, 3));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        other.GetComponent<Character>().HasJustTeleported = false;
    }
}
