using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private GM gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Galinha").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit(){
        gm.SceneLoader("Start");
    }

    public void Exit(){
        Application.Quit();
    }

    public void LevelSelector(){
        gm.SceneLoader("LevelSelector");

    }    
    public void Credits(){
        gm.SceneLoader("Credits");

    }
}
