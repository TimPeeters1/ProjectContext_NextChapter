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

        AIState = AIMovement.Move;
        StartCoroutine("StayFewSeconds");
    }

    void Update()
    {
        switch (AIState)
        {
            case AIMovement.Move:
        PointDistance = Vector3.Distance(transform.position, CurrentTarget);

        if(PointDistance <= 3)
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
        yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));

        CurrentTarget = targetArray[CurrentTargetNumber].transform.position;

        AIState = AIMovement.Move;
    }
}
