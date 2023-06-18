using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dusman : MonoBehaviour
{
    GameObject fullBody;

    void Start()
    {
    }
    public void CanDus(int darbe,GameObject body,string partOfbody)
    {
        fullBody = body.transform.root.gameObject;
        fullBody.GetComponent<dusmanFullBody>().CanDus(darbe,partOfbody);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
