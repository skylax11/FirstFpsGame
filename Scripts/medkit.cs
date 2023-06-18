using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class medkit : MonoBehaviour
{
    TextMeshProUGUI text;
    public int count = 0;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = count.ToString();
    }
}
