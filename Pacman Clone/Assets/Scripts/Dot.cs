using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D c) {
		if (c.name.Contains("Pacman")) {
			GameManager.currentScore += 1;
			Destroy(gameObject);
		}
	}
}
