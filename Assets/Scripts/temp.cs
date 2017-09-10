/*using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Maze : MonoBehaviour {
	public string path;
	public GameObject wall;
	public GameObject dot;

	// Use this for initialization
	void Start() {
		CreateMaze();	
	}

	void CreateMaze() {
		string[] text = System.IO.File.ReadAllLines(@path).Select(l => l.Trim()).ToArray();
		Debug.Log("Reading " + text[0].Length + "x" + text.Length + " array.");

		for (int y = text.Length-1; y >= 0; y--) {
			for (int x = 0; x < text[y].Length; x++) {
				if (text[y][x] == '#') {
					Instantiate(wall, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (text[y][x] == 'o') {
					Instantiate(dot, new Vector3(x, y, 0), Quaternion.identity);
				}
			}
		}
	}
}*/