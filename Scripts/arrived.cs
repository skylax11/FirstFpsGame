using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrived : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.transform.name);
    }

    void Update()
    {
        
    }
}
