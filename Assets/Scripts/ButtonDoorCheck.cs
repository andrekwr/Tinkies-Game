using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDoorCheck : MonoBehaviour
{
    public LayerMask playerMask;

    private void Start(){
        StartCoroutine(CheckDoor());
    }

    private IEnumerator CheckDoor(){
        while(true){
            yield return new WaitForSeconds(.05f);
            if(Physics2D.OverlapCircle(transform.position, 0.6f, playerMask)){
                transform.parent.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);
                while(Physics2D.OverlapCircle(transform.position, 0.6f, playerMask)){
                    transform.parent.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);
                    yield return new WaitForSeconds(.05f);
                }
                transform.parent.gameObject.GetComponent<Animator>().SetBool("IsOpen", false);
            }
        }
    }
}
