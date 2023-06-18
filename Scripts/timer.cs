using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    GameObject GN;
    float geleceklerizaman;
    GameObject araba;
    float time = 90;
    GameObject clock;
    void Start()
    {
        GN = GameObject.Find("GLOBALNETWORK");

        if (GN.GetComponent<GLOBAL>().Difficulty == "easy")
        {
            time = 60;
            geleceklerizaman = 30f;
        }
        if (GN.GetComponent<GLOBAL>().Difficulty == "normal")
        {
            time = 90;
            geleceklerizaman = 20f;
        }
        if (GN.GetComponent<GLOBAL>().Difficulty == "hard")
        {
            time = 120;
            geleceklerizaman = 15f;
        }

        clock = GameObject.Find("CountDown");
        araba = GameObject.Find("ZIL130");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            clock.GetComponent<TextMeshProUGUI>().text = time.ToString("F2");
            if (time <= geleceklerizaman)
            {
                araba.GetComponent<Animator>().SetTrigger("comeBack");
            }
        }
        else
        {
            time = 0;
            clock.GetComponent<TextMeshProUGUI>().text = time.ToString("F2");
        }
    }
}
