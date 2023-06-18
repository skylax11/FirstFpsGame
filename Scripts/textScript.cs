using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public int leþSayýsý;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Skor :" + " " +leþSayýsý.ToString();
    }
}
