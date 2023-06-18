using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class playerPROP : MonoBehaviour
{
    public int can = 100;
    GameObject cv;
    GameObject cv2;
    bool oldumu = false;
    public Volume volume;
    GameObject x;
    public int skor;
    GameObject skortutucu;
    
    void Start()
    {
        skortutucu = GameObject.Find("SkorTutucu");
        skor = GameObject.Find("skor").GetComponent<textScript>().leþSayýsý;
        x = GameObject.Find("PLAYER BLOOD");
    }

    void Update()
    {
        if (can <= 0)
        {
            skortutucu.GetComponent<Skor>().dedolunca(GameObject.Find("skor").GetComponent<textScript>().leþSayýsý);
            SceneManager.LoadScene("mainMenu");

        }
        if (can <= 49)
        {
            x.GetComponent<Volume>().enabled = true;
        }
        else
        {
            x.GetComponent<Volume>().enabled = false;
        }
    }
    public void CanDus(int darbe)
    {
        can -= darbe;
    }
}
