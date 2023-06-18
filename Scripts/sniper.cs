using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sniper : MonoBehaviour
{
    bool scope = false;
    bool bastiMi = false;
    TextMeshProUGUI txt;
    RaycastHit hit;
    RaycastHit Sniperhit;
    GameObject previousWep;
    GameObject script;
    GameObject cam;
    
    void Start()
    {
        script = GameObject.Find("FPS-AK47");
        cam = GameObject.Find("Camera").gameObject;
        txt = GameObject.Find("sniperText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            if (script.GetComponent<animationScript>().SelectedWep.name != "SVD")
            {
                previousWep = script.GetComponent<animationScript>().SelectedWep;
            }
            Debug.Log(previousWep.name);
            if (hit.transform.name == "SVD")
            {
                txt.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    #region
                    Debug.Log("Bastý");
                    
                    GameObject.Find("MAG").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("OPTICS").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("SVD_Body").GetComponent<MeshRenderer>().enabled = false;

                    if (previousWep.CompareTag("deagle"))
                    {
                        GameObject.Find("FPS-AK47").GetComponent<Animator>().SetBool("deaglesniper", true);

                    }
                    if (previousWep.CompareTag("ak47"))
                    {
                        GameObject.Find("FPS-AK47").GetComponent<Animator>().SetBool("sniper", true);

                    }

                    cam.GetComponent<Camera>().fieldOfView = 20f;
                    GameObject.Find("ScopeCanvas").GetComponent<Canvas>().enabled = true;

                    gameObject.GetComponent<playercontrol>().mouseSensitivity = 0.5f;
                    gameObject.GetComponent<playercontrol>().permission = false;
                    scope = true;

                    script.GetComponents<AudioSource>()[0].enabled = false;
                    script.GetComponents<AudioSource>()[1].enabled = false;
                    script.GetComponents<AudioSource>()[2].enabled = false;
                    script.GetComponents<AudioSource>()[3].enabled = false;
                    script.GetComponent<ak47>().enabled = false;
                    script.GetComponent<animationScript>().sniperMode = true;
                    #endregion
                    // 

                }
            }
            else
            {
                txt.enabled = false;

            }
        }
        if (scope == true)
        {
          
            
           if (Input.GetKeyDown(KeyCode.F))
           {
            bastiMi = true;
           }
            if (bastiMi)
            {
                #region
                GameObject.Find("MAG").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("OPTICS").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("SVD_Body").GetComponent<MeshRenderer>().enabled = true;
                cam.GetComponent<Camera>().fieldOfView = 60f;
                GameObject.Find("ScopeCanvas").GetComponent<Canvas>().enabled = false;
                gameObject.GetComponent<playercontrol>().mouseSensitivity = 3;
                bastiMi = false;
                scope = false;
                gameObject.GetComponent<playercontrol>().permission = true;
                if (previousWep.CompareTag("deagle"))
                {
                    GameObject.Find("FPS-AK47").GetComponent<Animator>().SetBool("deaglesniper", false);

                }
                if (previousWep.CompareTag("ak47"))
                {
                    GameObject.Find("FPS-AK47").GetComponent<Animator>().SetBool("sniper", false);

                }
                script.GetComponents<AudioSource>()[0].enabled = true;
                script.GetComponents<AudioSource>()[1].enabled = true;
                script.GetComponents<AudioSource>()[2].enabled = true;
                script.GetComponents<AudioSource>()[3].enabled = true;
                script.GetComponent<ak47>().enabled = true;
                script.GetComponent<animationScript>().sniperMode = false;

                if (previousWep.CompareTag("deagle"))
                {
                    Debug.Log("DEAGLE");
                    script.GetComponent<animationScript>().SelectedWep = previousWep;
                    GameObject.Find("ammo").GetComponent<reload>().weapon = previousWep;

                }
                if (previousWep.CompareTag("ak47"))
                {
                    Debug.Log("ak47");
                    script.GetComponent<animationScript>().SelectedWep = previousWep;
                    GameObject.Find("ammo").GetComponent<reload>().weapon = previousWep;
                }
                #endregion

            }
        }

    }
}
