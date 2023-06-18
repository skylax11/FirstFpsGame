using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    GameObject startbut;
    GameObject controls;
    TextMeshProUGUI text;
    Canvas howToPlayCanvas;

    void Start()
    {
        startbut = GameObject.Find("start");
        controls = GameObject.Find("control");
        text = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
        howToPlayCanvas = GameObject.Find("howtoplay").GetComponent<Canvas>();
    }

    void Update()
    {

    }
    public void StartGame()
    {
        GameObject.Find("difficulty").GetComponent<Canvas>().enabled = true;
        GameObject.Find("start").GetComponent<Button>().enabled = false;
        GameObject.Find("control").GetComponent<Button>().enabled = false;

    }
    public void Easy()
    {
        GameObject.Find("GLOBALNETWORK").GetComponent<GLOBAL>().Difficulty = "easy";
        SceneManager.LoadScene("SampleScene");
    }
    public void Normal()
    {
        GameObject.Find("GLOBALNETWORK").GetComponent<GLOBAL>().Difficulty = "normal";

        SceneManager.LoadScene("SampleScene");
    }
    public void Hard()
    {
        GameObject.Find("GLOBALNETWORK").GetComponent<GLOBAL>().Difficulty = "hard";
        SceneManager.LoadScene("SampleScene");
    }
    public void Controls()
    {
        howToPlayCanvas.enabled = true;
        startbut.SetActive(false);
        controls.SetActive(false);
        text.enabled = false;

    }
    public void GoBackMenu()
    {
        howToPlayCanvas.enabled = false;
        startbut.SetActive(true);
        controls.SetActive(true);
        text.enabled = true;
    }
}
