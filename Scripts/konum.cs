using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class konum : MonoBehaviour
{
    public GameObject gm;
    void Start()
    {
        InvokeRepeating("degis", 0.2f, 0.08f);

    }

    void Update()  
    {
    }
    void degis()
    {
        transform.LookAt(gm.transform.position);
    }
}
