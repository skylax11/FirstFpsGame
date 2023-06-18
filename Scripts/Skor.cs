using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skor : MonoBehaviour
{
    public static Skor Instance;
    public int skor;
    public int maxskor;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void dedolunca(int gelenskor)
    {

        skor = gelenskor;
        if (skor >= maxskor)
        {
            maxskor = skor;
        }
    }
    public void kazaninca(int gelenskor)
    {

        skor = gelenskor;
        if (skor >= maxskor)
        {
            maxskor = skor;
        }
    }


}
