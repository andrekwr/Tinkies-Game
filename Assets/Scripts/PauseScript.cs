using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool paused = false;
    public GameObject menu;
    private GM gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Galinha").GetComponent<GM>();
        menu.SetActive(false);

    }

    // Update is called once per frame


    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        paused = false;

    }
    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        paused = true;

    }

    public void Exit()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        //SceneManager.LoadScene("Start");
        gm.SceneLoader("Start");
        paused = false;
    }

    public void OnReset(){
        gm.GameOver();
        
        
    }

    public void OnPause()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}