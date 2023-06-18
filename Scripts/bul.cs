using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class bul : MonoBehaviour
{
    GameObject konum;
    RaycastHit hit;
    NavMeshAgent agent;
    public GameObject objct;
    Animator anm;
    bool devam = true;
    public GameObject Baskan1;
    public GameObject Baskan2;
    bool once = true;
    bool once2 = true;
    public GameObject SpawnPoint;
    public GameObject SpawnPoint2;
    GameObject finish;

    public bool didRealize = false;

    void Start()
    {
        finish = GameObject.Find("bitiþ");

        SpawnPoint = GameObject.Find("spawnCube");
        SpawnPoint2 = GameObject.Find("spawnCube2");

        objct = GameObject.Find("Oyuncu");
        Baskan1 = GameObject.Find("mainTarget1");
        Baskan2 = GameObject.Find("mainTarget2");

        konum = gameObject.GetComponentInChildren<konum>().gameObject;
        anm = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (finish.GetComponent<finish>().bittiMi == true)
        {
            didRealize = false;
        }
        if ((Baskan1.GetComponent<dusmanFullBody>().can <= 0 || Baskan2.GetComponent<dusmanFullBody>().can <= 0) || objct.GetComponentInChildren<animationScript>().kontrol == true)
        {
            if (finish.GetComponent<finish>().bittiMi == false && (didRealize == false || devam))
            {
                if (once2)
                {
                    SpawnPoint.GetComponent<spawn>().öldüMü = true;
                    SpawnPoint2.GetComponent<spawn2>().öldüMü = true;

                    once2 = false;
                }
                if (objct.GetComponent<timer>() == null)
                {
                    objct.AddComponent<timer>();
                }
                doIt();
                didRealize = true;
            }
        }
    }
    void doIt()
    {
        var distance = Vector3.Distance(gameObject.transform.position, objct.transform.position);

        GetCloser();

        if (once == true)
        {
            InvokeRepeating("ShootAt", 0.5f, 0.5f);
            once = false;
        }
        if (gameObject.GetComponent<dusmanFullBody>().can <= 0)
        {
            agent.isStopped = true;
            CancelInvoke("ShootAt");
        }
    }
    void ShootAt()
    {

        if (Physics.Raycast(konum.transform.position, konum.transform.forward, out hit, Mathf.Infinity) && finish.GetComponent<finish>().bittiMi == false)
        {
            anm.SetTrigger("Shoot");

            gameObject.GetComponent<dusmanFullBody>().aus.Play();

            if (hit.transform.name == objct.transform.name)
            {
                objct.GetComponent<playerPROP>().CanDus(Random.Range(5, 17));
            }
        }
    }
    void GetCloser()
    {

        if (Vector3.Distance(gameObject.transform.position, objct.transform.position) >= 25 && gameObject.GetComponent<dusmanFullBody>().can > 0)
        {
            anm.SetBool("walk", true);
            transform.position += transform.forward * Time.deltaTime * 3f;

        }
        else
        {
            anm.SetBool("walk", false);
        }


    }
}
