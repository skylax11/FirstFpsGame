using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    Animator anm;

    void Start()
    {
        anm = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        
    }


   


    void Update()
    {
        if (gameObject.GetComponent<dusmanFullBody>().CheckItOut == false && gameObject.GetComponent<dusmanFullBody>().can > 0)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                anm.SetBool("walk", false);
                anm.SetTrigger("turn");

                if (points.Length == 0)
                    return;
                agent.destination = points[destPoint].position;
                Debug.Log("evet");
                destPoint = (destPoint + 1) % points.Length;
            }
            else
            {
                anm.SetBool("walk", true);

            }
        }
        else
        {
            agent.isStopped = true;
        }


    }
}
