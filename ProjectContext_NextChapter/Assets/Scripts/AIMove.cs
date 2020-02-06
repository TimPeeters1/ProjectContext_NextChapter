using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    enum AIMovement
    {
        Stay,
        Move,
    }
    private NavMeshAgent agent;
    private Rigidbody AIrigid;
    private AIMovement AIState;

    int CurrentTargetNumber = 0;
    private Vector3 CurrentTarget;

    public  GameObject[] targetArray;

    float PointDistance;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AIrigid = GetComponent<Rigidbody>();
        agent.speed = Random.Range(2, 7);

        AIState = AIMovement.Move;
        StartCoroutine("StayFewSeconds");
    }

    void Update()
    {
        switch (AIState)
        {
            case AIMovement.Move:
        PointDistance = Vector3.Distance(transform.position, CurrentTarget);

        if(PointDistance <= 3.6f)
        {
                    AIState = AIMovement.Stay;
        }
        else
        {
            agent.SetDestination(CurrentTarget);
        }
                break;
            case AIMovement.Stay:
                StartCoroutine("StayFewSeconds");
                break;
        }
    }

    IEnumerator StayFewSeconds()
    {
        CurrentTargetNumber = Random.Range(1, targetArray.Length);
        yield return new WaitForSeconds(Random.Range(1.0f, 8.0f));

        CurrentTarget = targetArray[CurrentTargetNumber].transform.position;

        AIState = AIMovement.Move;
    }
}
