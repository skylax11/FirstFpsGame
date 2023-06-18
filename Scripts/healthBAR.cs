using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthBAR : MonoBehaviour
{
    int can;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        can = GameObject.Find("Oyuncu").GetComponent<playerPROP>().can;
        gameObject.GetComponent<TextMeshProUGUI>().text = can.ToString();
    }
}
