using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class kazandı : MonoBehaviour
{
    int skor;
    void Start()
    {
        kazaninca(GameObject.Find("SkorTutucu").GetComponent<Skor>().skor);
    }

    public void kazaninca(int gelenskor)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Kazandin! Yeni Skorun : " + " " + gelenskor;
    }
}
