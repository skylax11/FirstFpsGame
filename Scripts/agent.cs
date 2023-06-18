using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agent : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agentt;
    void Start()
    {
        agentt = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * 250f;
        transform.LookAt(player.transform.position);
    }
}
