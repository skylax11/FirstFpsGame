using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class dusmanFullBody : MonoBehaviour
{
    public GameObject player;
    public GameObject konum;

    bool head = true;
    bool chest=true;
    bool arm=true;

    GameObject cube;
    GameObject target;
    Animator anm;
    public AudioSource aus;
    RaycastHit hit;
    public bool CheckItOut = false;
    public int can = 100;
    bool girdiMi = false;
    bool girdiMi2 = true;
    public bool patrolling;
    bool x1 = false;
    bool x2 = true;
    void Start()
    {
        target = GameObject.Find("TargetToPlayer");
        cube = GameObject.Find("MERMI");
        anm = GetComponent<Animator>();
    }
    public void CanDus(int darbe,string partOfbody)
    {
        can -= darbe;
        if (can <= 0)
        {
            if (partOfbody == "head")
            {
                anm.SetBool("head", true);
                if (head)
                {
                    GameObject.Find("skor").GetComponent<textScript>().leþSayýsý = GameObject.Find("skor").GetComponent<textScript>().leþSayýsý + 15;
                    head = false;
                    chest = false;
                    arm = false;
                    if (gameObject.transform.name != "mainTarget1" && gameObject.transform.name != "mainTarget2")
                    {
                        Destroy(gameObject, 5f);
                    }


                }
            }
            if (partOfbody == "chest")
            {
                anm.SetBool("chest", true);
                if (chest)
                {
                    GameObject.Find("skor").GetComponent<textScript>().leþSayýsý = GameObject.Find("skor").GetComponent<textScript>().leþSayýsý + 10;
                    head = false;
                    chest = false;
                    arm = false;
                    if (gameObject.transform.name != "mainTarget1" && gameObject.transform.name != "mainTarget2")
                    {
                        Destroy(gameObject, 5f);
                    }


                }
            }
            if (partOfbody == "arm")
            {
                anm.SetBool("arm", true);
                if (arm)
                {
                    GameObject.Find("skor").GetComponent<textScript>().leþSayýsý = GameObject.Find("skor").GetComponent<textScript>().leþSayýsý + 5;
                    head = false;
                    chest = false;
                    arm = false;
                    if (gameObject.transform.name != "mainTarget1" && gameObject.transform.name != "mainTarget2")
                    {
                        Destroy(gameObject, 5f);
                    }
                }
            }

        }

    }

    void Update()
    {
        if (gameObject.GetComponent<bul>() != null)
        {
            if (gameObject.GetComponent<bul>().didRealize == false)
            {
                TheThing();
            }
            else
            {
                LookAt();
            }
        }
        else
        {
            TheThing();
        }




    }
    void LookAt()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);

    }
    void TheThing()
    {
        var Distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (GameObject.Find("FPS-AK47").GetComponents<AudioSource>()[0].isPlaying == true || GameObject.Find("FPS-AK47").GetComponents<AudioSource>()[3].isPlaying == true)
        {
            var distance2 = Vector3.Distance(GameObject.Find("FPS-AK47").GetComponents<AudioSource>()[0].gameObject.transform.position, gameObject.transform.position);
            var distance3 = Vector3.Distance(GameObject.Find("FPS-AK47").GetComponents<AudioSource>()[3].gameObject.transform.position, gameObject.transform.position);

            if ((distance2 < 35 || distance3 < 35) && (gameObject.GetComponent<dinleyen>() == null && gameObject.GetComponent<konusan>() == null))
            {
                CheckItOut = true;
            }

            if ((distance2 < 35 || distance3 < 35) && (gameObject.GetComponent<dinleyen>() != null || gameObject.GetComponent<konusan>() != null))
            {
                GameObject.Find("arka_dinleyen").GetComponent<dinleyen>().close();
                GameObject.Find("arka_konusan").GetComponent<konusan>().close();

            }
        }

        if ((can > 0 && Distance < 10) && (gameObject.GetComponent<dinleyen>() == null && gameObject.GetComponent<konusan>() == null))
        {
            CheckItOut = true;
        }
        if ((can > 0 && Distance < 10) && (gameObject.GetComponent<dinleyen>() != null || gameObject.GetComponent<konusan>() != null))
        {
            GameObject.Find("arka_dinleyen").GetComponent<dinleyen>().close();
            GameObject.Find("arka_konusan").GetComponent<konusan>().close();
        }
        if (can > 0 && CheckItOut == true)
        {
            anm.SetTrigger("Shoot");
            LookAt();
            girdiMi = true;
        }
        if (girdiMi == true && girdiMi2 == true)
        {
            gameObject.AddComponent<AI_Script>();   // LOL IM FUCKING GENIOUS HELL YEAH !!!!!!!!!!!!!!
            girdiMi2 = false;
        }
    }

}
