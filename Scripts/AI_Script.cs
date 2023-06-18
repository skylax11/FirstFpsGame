using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AI_Script : MonoBehaviour
{
    NavMeshAgent agent;
    RaycastHit hit;
    GameObject dusman;
    GameObject player;
    GameObject konum;
    Animator anm;
    GameObject finish;
    void Start()
    {
        finish = GameObject.Find("bitiþ");

        konum = gameObject.GetComponentInChildren<konum>().gameObject;
        anm = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Oyuncu");
        dusman = gameObject;
        InvokeRepeating("ShootAt", 0.5f, 0.5f);

    }
    void Update()
    {
        Debug.DrawRay(konum.transform.position, konum.transform.forward, Color.green);

        if (dusman.GetComponent<dusmanFullBody>().can < 0)
        {
            gameObject.GetComponent<AI_Script>().CancelInvoke("ShootAt");
        }
        if ((gameObject.GetComponent<dusmanFullBody>().CheckItOut == true && gameObject.GetComponent<dusmanFullBody>().patrolling == false) && dusman.GetComponent<dusmanFullBody>().can >= 0)
        {
            GetCloser();
        }
    }
    void ShootAt()
    {

        if (Physics.Raycast(konum.transform.position, konum.transform.forward, out hit, Mathf.Infinity) && finish.GetComponent<finish>().bittiMi == false)
        {
            Debug.DrawRay(konum.transform.position, konum.transform.forward, Color.green);

            Debug.Log(hit.transform.name);

            gameObject.GetComponent<dusmanFullBody>().aus.Play();

            if (hit.transform.name == player.transform.name)
            {
                player.GetComponent<playerPROP>().CanDus(Random.Range(5, 17));
            }
        }
    }
    void GetCloser()
    {

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= 15)
        {
            anm.SetBool("walk", true);
            agent.SetDestination(player.transform.position);
            transform.position += transform.forward * Time.deltaTime * 3f;

        }
        else
        {
            anm.SetBool("walk", false);
        }
 

    }
}
