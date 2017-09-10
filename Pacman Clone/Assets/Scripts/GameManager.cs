using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static int currentScore = 0;

	void OnGUI() {
		int x = Screen.width/2;
		int y = Screen.height/2;
		int mx = Maze.width/2;
		int my = Maze.height/2;
		GUI.Label(new Rect(x-(mx*13)-50, y-(my*13), 100, 100), "Score\n" + currentScore);
		GUI.Label(new Rect(x+(mx*13), y-(my*13), 100, 100), "Highscore\n" + PlayerPrefs.GetInt("highscore", 0));

		if (GUI.Button(new Rect(x-31, y-(my*13)-50, 50, 20), "Reset")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			currentScore = 0;
		}
	}
}
