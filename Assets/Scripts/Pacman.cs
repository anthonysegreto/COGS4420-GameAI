using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour {
	float speed = 0.12f;
	Vector2 dest = Vector2.zero;
	Vector2 dir = Vector2.zero;
	Vector2 newDir = Vector2.zero;

	// Use this for initialization
	void Start () {
		dest = transform.position;
	}

	bool CanMove(Vector2 dir) {
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return hit.collider.name.Contains("Dot") || (hit.collider == GetComponent<Collider2D>());
	}

	void UpdateOrientation(Vector2 dir) {
		if (dir == Vector2.up) {
			transform.localScale = new Vector3(1,1,1);
			transform.localRotation = Quaternion.Euler(0,0,90);
		}
		else if (dir == Vector2.down) {
			transform.localScale = new Vector3(1,1,1);
			transform.localRotation = Quaternion.Euler(0,0,270);
		}
		else if (dir == Vector2.left) {
			transform.localScale = new Vector3(-1,1,1);
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
		else if (dir == Vector2.right) {
			transform.localScale = new Vector3(1,1,1);
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			newDir = Vector2.up;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			newDir = Vector2.down;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			newDir = Vector2.left;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			newDir = Vector2.right;
		}

		if ((Vector2)transform.position == dest) {
			if (CanMove(newDir)) {
				dir = newDir;
			}
			else {
				if (!CanMove(dir)) {
					dir = Vector2.zero;
				}
			}
			dest = (Vector2)transform.position + dir;
		}
		transform.position = Vector2.MoveTowards(transform.position, dest, speed);
		UpdateOrientation(dir);
	}
}
