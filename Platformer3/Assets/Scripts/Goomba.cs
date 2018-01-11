using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : Foe {

	public enum GoombaState {
		WALK, DEAD
	};

	public GoombaState currentState;

	// Use this for initialization
	new void Start () {
		base.Init ();
		state = new FiniteStateMachine ();
		state.AddState (new FoeWalk (this, moveSpeed, flipAtPlatformEnd));
		state.AddState (new FoeDead (this));
		state.SetState ((int)currentState);
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//}
}
