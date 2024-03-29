﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract Class from which all characters in the game will derive from.
/// </summary>


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public abstract class Character : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private InputType touchInput;
    public bool HasJustTeleported { get; set; }
    public Direction facingDirection;

    /// <summary>
    /// Make Navmesh Agent move to certain destination
    /// </summary>
    /// <param name="destination"></param>
    public virtual void Move(Vector3 destination)
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(destination);
    }

    /// <summary>
    /// Pass in a direction to Raycast in
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public bool RaycastInDirection(Direction direction, out RaycastHit hit)
    {
        Vector3 raycastDirection;
        switch (direction)
        {
            case Direction.FORWARD:
                {
                    raycastDirection = new Vector3(1, 0, 0);
                    break;
                }
            case Direction.BACKWARD:
                {
                    raycastDirection = new Vector3(-1, 0, 0);
                    break;
                }
            case Direction.RIGHT:
                {
                    raycastDirection = new Vector3(0, 0, -1);
                    break;
                }

            case Direction.LEFT:
                {
                    raycastDirection = new Vector3(0, 0, 1);
                    break;
                }
            default:
                {
                    raycastDirection = new Vector3();
                    break;
                }
        }
        Vector3 raycastOrigin = transform.position;
        raycastOrigin.y += 1;
        Debug.DrawRay(raycastOrigin, raycastDirection);
        return Physics.Raycast(raycastOrigin, raycastDirection, out hit,4);
    }
    /// <summary>
    /// Sets the direction in which the character is facing. Also updates the Direction variable.
    /// </summary>
    /// <param name="direction"></param>
    public void SetCharacterDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.RIGHT:
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, 0);
                    break;
                }
            case Direction.LEFT:
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
                    break;
                }
            case Direction.FORWARD:
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 0);
                    break;
                }
            case Direction.BACKWARD:
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, 0);
                    break;
                }
        }
        facingDirection = direction;
    }


    /// <summary>
    /// Override this function to impart attack function to the character
    /// </summary>
    /// <param name="target"></param>
    public virtual void Attack(GameObject target)
    {
        print("Not implemented");
    }

    /// <summary>
    /// The game is split into Player phase and an AI phase
    /// This function executes in the update loop of the GameLoopManager
    /// </summary>
    public virtual void PhaseBehavior(TouchCommand command)
    {
        print("Not implemented");
    }
}
