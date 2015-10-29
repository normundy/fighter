﻿using UnityEngine;
using System.Collections;

public class Sanji : Character {

	public void kick(GameObject collider, GameObject hitter) {
		// here we would apply damage unique to Sanji's kick
		// I think we should also apply the movement vector here for the collider, current implementation is actually quite bad
		// as the collider sets its own direction, which has nothing to do with what hit it. Didn't want to go too far on changing
		// everything for now though.
		collider.GetComponent<PlayerMovement>().wasThrown (hitter.transform.position.x - collider.transform.position.x);
	}

}