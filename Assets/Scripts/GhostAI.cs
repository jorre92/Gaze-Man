using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

enum State
{
    FollowPlayer,
    Dumb
}
public class GhostAI : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    public float fitness = 0;

    private State whatToDO = State.FollowPlayer;
    private float timeToSwap = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeToSwap -= Time.deltaTime;

        if ( timeToSwap <= 0)
        {
            updateState();
            timeToSwap = 2.0f;
        }

        switch(whatToDO)
        {
            case State.FollowPlayer:
                agent.speed = 3.0f;
                agent.SetDestination(player.transform.position);
            break;
            case State.Dumb:
                agent.speed = 0.5f;
            break;

        }
        

    }

    void updateState()
    {
        float value = Random.Range(0.0f, 1.0f);
        if ( value < fitness )
        {
            whatToDO = State.FollowPlayer;
        }
        else
        {
             whatToDO = State.Dumb;
             var listOfCandies = GameObject.FindGameObjectsWithTag("Candie");

            if ( listOfCandies.Length == 0 )
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                agent.SetDestination(listOfCandies[Random.Range(0, listOfCandies.Length)].transform.position);
            }
              
        }
    }
}
