using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
	override public void MovePlayer(){
		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}
		base.MovePlayer();
	}
}
