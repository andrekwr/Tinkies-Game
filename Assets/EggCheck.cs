using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCheck : MonoBehaviour
{
    public LayerMask playerMask;
    private GM loader;
    void Start(){
        loader = GameObject.Find("Galinha").GetComponent<GM>();
    }
    private void Update() {
        if(Physics2D.OverlapCircle(transform.position, 2.5f, playerMask)){
            loader.NextLevel();
        }
    }
}
