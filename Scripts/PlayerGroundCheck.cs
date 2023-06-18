using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    playercontrol controller;

    bool onlyOnce = true;
    bool onlyOnce2 = true;
    bool onlyOnce3 = true;
    bool onlyOnce4 = true;
    bool indi = false;
    public bool AmmoGround = false;
    public bool medGround = false;
    public bool bindiMi = false;
    
    private void Awake()
    {
        
        controller = GetComponentInParent<playercontrol>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == controller.gameObject)
        {
            return;
        }
        controller.SetGroundedState(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller.gameObject)
        {
            return;
        }
        controller.SetGroundedState(false);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller.gameObject)
        {
            return;
        }
        if (onlyOnce == true && other.CompareTag("ground"))
        {
            onlyOnce = false;
            GameObject.Find("ZIL130").GetComponent<Animator>().SetTrigger("trigger");
            indi = true;

        }
        
        if (other.CompareTag("getincar"))
        {
            GameObject.Find("FirstAnim").GetComponent<Animator>().SetTrigger("bindi");
            bindiMi = true;
        }
        if (onlyOnce3 == true && other.CompareTag("med"))
        {
            GameObject.Find("Oyuncu").AddComponent<med>();
            onlyOnce3 = false;
        }
        if (other.CompareTag("med"))
        {
            medGround = true;
        }
        else
        {
            medGround = false;
        }
        if (onlyOnce2 == true && other.transform.name == "sniper_ground")
        {
            onlyOnce2 = false;
            GameObject.Find("Oyuncu").AddComponent<sniper>();
        }
        if (onlyOnce4 == true && other.CompareTag("AmmoFloor"))
        {
            GameObject.Find("Oyuncu").AddComponent<GETammo>();
            onlyOnce4 = false;

        }
        if (other.CompareTag("AmmoFloor"))
        {
            AmmoGround = true;
        }
        else
        {
            AmmoGround = false;
        }

        controller.SetGroundedState(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == controller.gameObject)
        {
            return;
        }

        controller.SetGroundedState(true);
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject == controller.gameObject)
        {
            return;
        }
        controller.SetGroundedState(false);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == controller.gameObject)
        {
            return;
        }

        controller.SetGroundedState(true);
    }
}
