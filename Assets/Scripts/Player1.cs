using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
	public override void MovePlayer(){
        if (controller.spring){
			velocity.y = 25;
			GetComponent<AudioSource>().Play();
			controller.spring = new RaycastHit2D();
		}
		else if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}
        base.MovePlayer();

    }
}
