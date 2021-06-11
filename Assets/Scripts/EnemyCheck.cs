using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{

    public LayerMask player1Mask;
    public LayerMask player2Mask;

    private GM gm;

    void Start()
    {
        gm = GameObject.Find("Galinha").GetComponent<GM>();
    }

    void Update()
    {
        if (Physics2D.OverlapBox(new Vector2(transform.position.x - 0.06f, transform.position.y - .06f), new Vector2(.48f,.8f), 0, player1Mask)){
            gm.GameOver();
        }
        if (Physics2D.OverlapBox(new Vector2(transform.position.x - 0.06f, transform.position.y - .06f), new Vector2(.48f,.8f), 0, player2Mask)){
            gm.gameObject.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/345083__metrostock99__hey-very-low-4"));
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawCube(new Vector2(transform.position.x - 0.06f, transform.position.y - .06f), new Vector2(.48f,.8f));
    }
}
