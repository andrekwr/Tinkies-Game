using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public Animator galinhaAnimation;
    public AudioClip deathClip;
    public bool tocou;
    void Start() {
        galinhaAnimation = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    public void GameOver(){
        if(!tocou){
            tocou = true;
            gameObject.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/450616__breviceps__8-bit-error (1)"));
        }
        StartCoroutine(load(SceneManager.GetActiveScene().name));
    }
    
    public void NextLevel(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("levelReached", SceneManager.GetActiveScene().buildIndex)){
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex );
        }
        StartCoroutine(load(NameOfSceneByBuildIndex((SceneManager.GetActiveScene().buildIndex + 1))));
    }

    public void SceneLoader(string LevelName) {
        StartCoroutine(load(LevelName));

    }

    private IEnumerator load(string LevelName) {

        galinhaAnimation.SetTrigger("Fade");
        yield return new WaitForSeconds(0.84f);
        SceneManager.LoadScene(LevelName);

    }

    public static string NameOfSceneByBuildIndex(int buildIndex)
    {
     string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
     int slash = path.LastIndexOf('/');
     string name = path.Substring(slash + 1);
     int dot = name.LastIndexOf('.');
     return name.Substring(0, dot);
 }
}
