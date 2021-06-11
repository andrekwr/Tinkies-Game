using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private GM loader;

    public Button[] levelsBut;
    void Start(){
        loader = GameObject.Find("Galinha").GetComponent<GM>();

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelsBut.Length; i++)
        {
            if(i + 1 > levelReached){
                levelsBut[i].interactable = false;
            }
        }
    }

    public void Select(string LevelName) {
        loader.SceneLoader(LevelName);
        
         
    }
}
