using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public int le�Say�s�;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Skor :" + " " +le�Say�s�.ToString();
    }
}
