using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCheck : MonoBehaviour
{
    public LayerMask player1Mask;
    public LayerMask player2Mask;

    public GM gm;

    private void Start() {
        gm = GameObject.Find("Galinha").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.095f, player2Mask)){
            gm.GameOver();
        }
        if(Physics2D.OverlapCircle(transform.position, 0.095f, player1Mask)){
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .095f);
    }
}
