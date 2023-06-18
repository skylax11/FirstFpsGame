using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class maxskor : MonoBehaviour
{
    int skor;
    void Start()
    {
        skor = GameObject.Find("SkorTutucu").GetComponent<Skor>().maxskor;
        dedolunca(skor);
    }

    public void dedolunca(int gelenskor)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Max Skorun : " + " " + gelenskor;
    }
}
