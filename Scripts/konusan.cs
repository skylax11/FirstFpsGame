using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class konusan : MonoBehaviour
{
    public GameObject player;
    public GameObject arkadas;
    void Start()
    {

    }

    void Update()
    {
        if (arkadas.GetComponent<dusmanFullBody>().can <= 0 && gameObject.GetComponent<dusmanFullBody>().can > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("runaway", true);
        }
    }
    public void close()
    {
        gameObject.GetComponent<Animator>().SetBool("runaway", true);
    }
}
