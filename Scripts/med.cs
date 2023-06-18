using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class med : MonoBehaviour
{
    GameObject cam;
    Canvas canvas;
    GameObject floor;
    GameObject kit;
    public GameObject currentMed;
    RaycastHit hit;
    void Start()
    {
        kit = GameObject.Find("kit");
        floor = GameObject.Find("GroundCheck");
        cam = GameObject.Find("Camera").gameObject;
    }

    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("medBOX") && floor.GetComponent<PlayerGroundCheck>().medGround == true)
            {
                canvas = hit.transform.gameObject.GetComponentInChildren<Canvas>();

                Debug.Log("görüyor");
                canvas.enabled = true;
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Destroy(hit.transform.gameObject);
                    kit.GetComponent<medkit>().count++;
                }
            }
            else
            {
                canvas.enabled = false;
            }
        }
    }
}
