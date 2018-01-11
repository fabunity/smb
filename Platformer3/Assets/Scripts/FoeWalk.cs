using System;
using UnityEngine;

public class FoeWalk : State
{
	public FoeWalk (Foe Parent, float Speed, bool fpe) {
		parent = Parent;
		speed = Speed;
		flipAtPlatformEnd = fpe;

	}

	public override void Start() {
		
	}

	public override void Update() {
		// if hitting a wall, flip direction
		if (parent.Controller.collisions.left)
		{
			parent.direction = 1.0f;
		}
		if (parent.Controller.collisions.right)
		{
			parent.direction = -1.0f;
		}

		if (parent.Controller.collisions.below && flipAtPlatformEnd)
		{
			// check if we are at end of platform
			if (!parent.Controller.collisions.platformExists)
			{
				parent.direction *= -1.0f;
			}
		}
		parent.vx = speed * parent.direction;
		//Debug.Log (speed);
	}


	Foe parent;
	float speed;
	//public bool flipSprite;
	public bool flipAtPlatformEnd ;
}


