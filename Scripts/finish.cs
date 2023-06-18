using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    public bool bittiMi=false;
    void Start()
    {

    }
    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.transform.name == "Oyuncu")
        {
            StartCoroutine("bitti");
            bittiMi = true;
        }
    }

    void Update()
    {

    }
    IEnumerator bitti()
    {
        GameObject.Find("SkorTutucu").GetComponent<Skor>().kazaninca(GameObject.Find("skor").GetComponent<textScript>().leþSayýsý);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("bitiþ");
    }
}
