using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GETammo : MonoBehaviour
{
    GameObject cam;
    RaycastHit hit;
    GameObject floor;
    Canvas canvas;


    void Start()
    {
        floor = GameObject.Find("GroundCheck");
        cam = GameObject.Find("Camera").gameObject;
    }

    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {

            if (hit.transform.CompareTag("Ammo") && floor.GetComponent<PlayerGroundCheck>().AmmoGround== true)
            {
                canvas = hit.transform.gameObject.GetComponentInChildren<Canvas>();

                Debug.Log("GÝRDÝ");
                canvas.enabled = true;
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Destroy(hit.transform.gameObject);
                    if (gameObject.GetComponentInChildren<animationScript>().SelectedWep.CompareTag("ak47"))
                    {
                        gameObject.GetComponentInChildren<animationScript>().SelectedWep.GetComponent<WEAPON>().yedekMermi = 90;

                    }
                    if (gameObject.GetComponentInChildren<animationScript>().SelectedWep.CompareTag("deagle"))
                    {
                        gameObject.GetComponentInChildren<animationScript>().SelectedWep.GetComponent<WEAPON>().yedekMermi = 35;
                    }


                }
            }
            else
            {
                Debug.Log("GÝRMEDÝ");

                canvas.enabled = false;
            }
        }
    }
}
