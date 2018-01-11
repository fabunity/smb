using System;
using UnityEngine;

public class FoeDead : State {

	public FoeDead (Foe Parent) {
		parent = Parent;

	}

	public override void Start() {
		parent.anim.SetBool ("dead", true);
	}

	public override void Update() {
		parent.vx = 0.0f;
		deadTimer += Time.deltaTime;
		if (deadTimer > 2)
			MonoBehaviour.Destroy(parent.gameObject);
	}

	float deadTimer = 0.0f;
	Foe parent;
}