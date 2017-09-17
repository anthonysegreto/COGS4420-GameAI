using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour {
	float wanderOffset = 1;
	float wanderRadius = 0.5f;
	Vector2 direction = Vector2.zero;
	Vector2 wanderDest = Vector2.zero;
	float speed = 0.05f;

	// Use this for initialization
	void Start () {
		// Change this later
		direction = transform.right;
		DynamicWander();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ((Vector2)transform.position == wanderDest) {
			wanderDest = DynamicWander();
		}
		transform.position = Vector2.MoveTowards(transform.position, wanderDest, speed);
	}

	Vector2 DynamicWander() {
		Vector2 circleCenter = (Vector2)transform.position + (direction * wanderOffset);
		Vector2 dest = circleCenter + (Random.insideUnitCircle * wanderRadius).normalized;
		Debug.Log(dest);
		return dest;
	}
}
