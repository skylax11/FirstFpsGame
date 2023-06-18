using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEAPON : MonoBehaviour
{
    public int mermi;
    public int standart;
    public int mevcutMermi;
    public int yedekMermi;
    public int darbe;
    public int gereken;
    public int maxHasarHead;
    public int maxHasarBody;
    public int maxHasarLeg;
    public float atesEtmeSıkligi;

    void Start()
    {
    

    }
    public void Reload()
    {
        if (yedekMermi - standart >= 0)
        {
            gereken = standart - mevcutMermi;
            mevcutMermi += gereken;
            yedekMermi -= gereken;
        }
        else
        {
            gereken = standart - mevcutMermi;
            if (gereken >= yedekMermi)
            {
                mevcutMermi += yedekMermi;
                yedekMermi =0;

            }
            else
            {
                mevcutMermi += gereken;
                yedekMermi -=gereken;
            }

        }

    }
    public void Ates()
    {
        mevcutMermi--;
    }

    void Update()
    {

    }
}
