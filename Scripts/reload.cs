using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class reload: MonoBehaviour
{
    public GameObject weapon;
    GameObject ak47;
    GameObject deagle;
    GameObject sniper;

    void Start()
    {
        ak47 = GameObject.Find("FPS-AK47");
        deagle = GameObject.Find("pistol2");
        sniper = GameObject.Find("SVD");
        weapon = ak47;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = deagle;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = ak47;
        }
        if (GameObject.Find("FPS-AK47").GetComponent<animationScript>().sniperMode==true)
        {
            weapon = sniper;
        }
      
        gameObject.GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<WEAPON>().mevcutMermi + " / " + weapon.GetComponent<WEAPON>().yedekMermi;
        

    }
}
