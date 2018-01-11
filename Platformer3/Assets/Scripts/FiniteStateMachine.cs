using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
	abstract public void Update ();
	abstract public void Start ();
}


public class FiniteStateMachine
{
	public FiniteStateMachine ()
	{
		//state = State;
		states = new List<State> ();
	}

	public void AddState (State state) {
		states.Add (state);
	}

	public void Update () {
		//Debug.Log (state);
		states [state].Update ();
	}

	public void SetState (int State) {
		// do nothing if we try to switch to the current state
		if (state == State) {
			return;
		}

		state = State;
		states [state].Start ();
		
	}

	int state;
	List<State> states;
}


