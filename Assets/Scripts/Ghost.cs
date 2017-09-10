using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
	float speed = 0.12f;
	Vector2 dest = Vector2.zero;
	Vector2 dir = Vector2.zero;

	// Use this for initialization
	void Start () {
		dir = GetRandomDirection();
		dest = transform.position;
	}

	List<Vector2> GetValidDirections() {
		List<Vector2> directions = new List<Vector2>();
		if (CanMove(Vector2.up))
			directions.Add(Vector2.up);
		if (CanMove(Vector2.down))
			directions.Add(Vector2.down);
		if (CanMove(Vector2.left))
			directions.Add(Vector2.left);
		if (CanMove(Vector2.right))
			directions.Add(Vector2.right);
		return directions;
	}

	Vector2 GetRandomDirection() {
		List<Vector2> dirs = GetValidDirections();		
		System.Random rnd = new System.Random();
		int r = rnd.Next(dirs.Count);
		return dirs[r];

	}
	
	bool CanMove(Vector2 dir) {
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return hit.collider.name.Contains("Dot") || (hit.collider == GetComponent<Collider2D>());
	}

	// Update is called once per frame
	void FixedUpdate () {
		if ((Vector2)transform.position == dest) {
			if (!CanMove(dir)) {
				dir = GetRandomDirection();
			}
			else if (GetValidDirections().Count > 2) {
				dir = GetRandomDirection();
			}
			dest = (Vector2)transform.position + dir;
		}

		Vector2 facing = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", facing.x);
		GetComponent<Animator>().SetFloat("DirY", facing.y);
		transform.position = Vector2.MoveTowards(transform.position, dest, speed);
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.name.Contains("Pacman")) {
			if (GameManager.currentScore > PlayerPrefs.GetInt("highscore"))
				PlayerPrefs.SetInt("highscore", GameManager.currentScore);
			Destroy(c.gameObject);
		}
		else if (c.name.Contains("Ghost")) {
			dest = (Vector2)transform.position + (Vector2)(-transform.forward);
		}
	}
}
