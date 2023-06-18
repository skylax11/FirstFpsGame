using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn2 : MonoBehaviour
{
    GameObject GN;
    GameObject konum;
    public GameObject enemy;
    public GameObject reporter;
    public GameObject player;
    public bool öldüMü = false;
    void Start()
    {

        GN = GameObject.Find("GLOBALNETWORK");
        if (GN.GetComponent<GLOBAL>().Difficulty == "easy")
        {
            InvokeRepeating("Spawn", 15f, 8f);
        }
        if (GN.GetComponent<GLOBAL>().Difficulty == "normal")
        {
            InvokeRepeating("Spawn", 12f, 6f);
        }
        if (GN.GetComponent<GLOBAL>().Difficulty == "hard")
        {
            InvokeRepeating("Spawn", 6f, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        if (öldüMü && player.GetComponentInChildren<PlayerGroundCheck>().bindiMi == false)
        {
            Debug.Log("Spawnlandi");
            GameObject x = Instantiate(enemy, new Vector3(Random.Range(37, 43), 0, Random.Range(574, 577)), Quaternion.identity);
            x.GetComponent<dusmanFullBody>().player = player;
            konum = x.GetComponentInChildren<konum>().gameObject;
            konum.GetComponent<konum>().gm = player;

        }
    }
}
