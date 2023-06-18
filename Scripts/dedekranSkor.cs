using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dedekranSkor : MonoBehaviour
{
    int skor;
    void Start()
    {
        skor = GameObject.Find("SkorTutucu").GetComponent<Skor>().skor;
        dedolunca(skor);
    }
    public void dedolunca(int gelenskor)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Öldün! Yeni Skorun : " + " " + gelenskor;
    }

}
