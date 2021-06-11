using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos;
    public float stopSeconds;
    public float vel;
    private bool trocou;
    private Animator animator;
    public bool isWalker;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        pos1 = this.gameObject.transform.GetChild(1).transform.position;
        pos2 = this.gameObject.transform.GetChild(2).transform.position;
        pos = pos2;
    }

    private void Update() {
        if (isWalker){
            transform.position = Vector3.MoveTowards(transform.position, pos, vel*Time.deltaTime);
            if(Mathf.Abs(transform.position.x-pos.x) < 0.01 && (!trocou)){
                StartCoroutine(ChangePos());
                trocou = true;
            }
        }
    }

    private IEnumerator ChangePos(){
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(stopSeconds);
        pos = pos == pos1 ? pos2 : pos1;
        trocou = false;
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
        animator.SetBool("Walk", true);
    }


}
