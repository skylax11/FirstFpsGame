using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class animationScript : MonoBehaviour
{
    RaycastHit hit;
    Animator anim;
    public GameObject pc;
    public GameObject Raypoint;
    public AudioSource voice;
    public AudioSource voiceReload;
    public AudioSource deagleshot;
    public AudioSource deagleReload;
    public AudioSource AWM;
    public bool kontrol=false;

    GameObject kanefekt;

    public Camera cam;
    float atesEtmeSuresi;
    public float atesEtmeSýkligi;
    public float menzil;
    bool animasyon1 = true;
    bool animasyon2 = true;
    float cooldownRELOAD = 3f;
    bool firstWEP= true;
    bool secondWEP = false;
    GameObject SecWep;
    public GameObject SelectedWep;
    GameObject pc2;
    bool once=true;
    bool once2 =true;

    public bool sniperMode = false;

    void Start()
    {
        kanefekt = GameObject.Find("Kan");
        SelectedWep = gameObject;
        SecWep = GameObject.Find("pistol2");
        gameObject.GetComponent<ak47>().Wak47();
        pc = GameObject.Find("MuzzleFlashEffect").gameObject;
        pc2 = GameObject.Find("deagleMuzzle").gameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("sýk", false);
        anim.SetBool("reload", false);
        anim.SetBool("deagleShot", false);
        anim.SetBool("reloadDeagle", false);

        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green);

        if (Input.GetMouseButton(0))
        {
            if (Input.GetKey(KeyCode.R))
            {
                animasyon1 = true;
                animasyon2 = false;
                leftClick();
            }
            else
            {
                animasyon1 = true;
                animasyon2 = false;
                leftClick();
            }

        }
        if (Input.GetKey(KeyCode.R))
        {
            if (Input.GetMouseButton(0))
            {
                animasyon2 = false;
                animasyon1 = true;
            }
            else
            {
                animasyon2 = true;
                animasyon1 = true;
                R();
            }
        }
    }

    void R()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (animasyon2 == true && firstWEP == true)
            {
                voiceReload.Play();
                anim.SetBool("reload", true);
                if (SelectedWep.CompareTag("ak47"))
                {
                    SelectedWep.GetComponent<WEAPON>().Reload();
                }
            }
            if (secondWEP == true)
            {
                deagleReload.Play();
                anim.SetBool("reloadDeagle", true);

                if (SelectedWep.CompareTag("deagle"))
                {
                    SelectedWep.GetComponent<WEAPON>().Reload();
                }
            }
            if (sniperMode == true)
            {
                if (SelectedWep.CompareTag("sniper"))
                {
                    SelectedWep.GetComponent<Sniper>().Reload();
                }
            }

        }
    }
    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedWep = SecWep;
            if (once)
            {
                SelectedWep.GetComponent<deagle>().Mdeagle();
                once = false;
            }

            secondWEP = true;
            firstWEP = false;
            anim.SetTrigger("Pressed");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWep = gameObject;
            firstWEP = true;
            secondWEP = false;
            anim.SetTrigger("DeagleToAk");
        }
        if (sniperMode == true)
        {
            SelectedWep = GameObject.Find("SVD").gameObject;
            if (once2)
            {
                SelectedWep.GetComponent<Sniper>().sniper();
                once2= false;
            }
        }
    }
    void leftClick()
    {
        if ((Input.GetMouseButton(0) && Time.time > atesEtmeSuresi) && SelectedWep.GetComponent<WEAPON>().mevcutMermi != 0 && animasyon2 != true)
        {
            
            if (animasyon1 == true && firstWEP == true)
            {
                AtesEt();
                pc.GetComponent<ParticleSystem>().Play();
                voice.Play();
                anim.SetBool("sýk", true);
                if (SelectedWep.CompareTag("ak47"))
                {
                    SelectedWep.GetComponent<WEAPON>().Ates();
                }
            }
            if (secondWEP == true)
            {
                pc2.GetComponent<ParticleSystem>().Play();
                anim.SetBool("deagleShot", true);
                Debug.Log("Ates etti");
                deagleshot.Play();
                AtesEt();
                if (SelectedWep.CompareTag("deagle"))
                {
                    SelectedWep.GetComponent<WEAPON>().Ates();
                }
            }
            if (sniperMode == true)
            {
                AtesEt();
                AWM.Play();

                if (SelectedWep.CompareTag("sniper"))
                {
                    kontrol = true;
                    Debug.Log("GÝRDÝÝÝÝÝÝÝÝÝ   :"+SelectedWep.name);
                    SelectedWep.GetComponent<Sniper>().Ates();
                }

            }

            atesEtmeSuresi = Time.time + SelectedWep.GetComponent<WEAPON>().atesEtmeSýkligi;
            
        }
    }
    void AtesEt()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity) && SelectedWep.GetComponent<WEAPON>().mevcutMermi !=0)
        {
            Debug.Log(hit.transform.name);
            Debug.Log(SelectedWep.GetComponent<WEAPON>().name);

            

            if (hit.transform.CompareTag("dusman"))
            {
                kanefekt.transform.position = hit.transform.position;
                kanefekt.GetComponent<ParticleSystem>().Play();

                if (hit.transform.GetComponent<CapsuleCollider>() != null)
                {
                    hit.transform.GetComponent<dusman>().CanDus(Random.Range(10, SelectedWep.GetComponent<WEAPON>().maxHasarLeg), hit.transform.gameObject,"arm");

                }
                if (hit.transform.GetComponent< BoxCollider>()!= null)
                {
                    hit.transform.GetComponent<dusman>().CanDus(Random.Range(25, SelectedWep.GetComponent<WEAPON>().maxHasarBody), hit.transform.gameObject, "chest");

                }
                if (hit.transform.GetComponent<SphereCollider>() != null)
                {
                    hit.transform.GetComponent<dusman>().CanDus(SelectedWep.GetComponent<WEAPON>().maxHasarHead,hit.transform.gameObject,"head");

                }
            }

        }
    }
}
