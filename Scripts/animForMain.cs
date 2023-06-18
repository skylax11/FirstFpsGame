using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animForMain : MonoBehaviour
{
    public GameObject Friend;
    GameObject enemy;
    void Start()
    {
        enemy = GameObject.Find("Oyuncu");
    }
    void Update()
    {
        if (Friend.GetComponent<dusmanFullBody>().can <= 0 || enemy.GetComponentInChildren<animationScript>().kontrol == true)
        {
            gameObject.GetComponent<Animator>().SetTrigger("dead");
        }
    }
}
