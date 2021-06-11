using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
    public LayerMask deathMask;
    private GM gm;

    private void Start() {
        gm = GameObject.Find("Galinha").GetComponent<GM>();
    }
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 1f, deathMask)){
            gm.GameOver();
        }
    }
}
