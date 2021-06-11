using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public bool left = false;
    public bool right = false;
    public bool jump = false;
    public bool jumpRelease = false;
    public bool leftRelease = false;
    public bool rightRelease = false;
    private void OnLeft(){
        left = true;
    }
    private void OnRight(){
        right = true;
    }
    private void OnJump(){
        jump = true;
    }
    private void OnJumpRelease(){
        jumpRelease = true;
    }
    private void OnLeftRelease(){
        left = false;
    }
    private void OnRightRelease(){
        right = false;
    }
}
